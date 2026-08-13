enum ViewState
{
	Idle,
	Loading,
	Content,
	Error,
	Cancelled
}

sealed class AsyncActionController
{
	int isRunning;

	public ViewState State { get; private set; } = ViewState.Idle;

	public async Task<bool> ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken)
	{
		if (Interlocked.Exchange(ref isRunning, 1) == 1)
		{
			return false;
		}

		try
		{
			State = ViewState.Loading;
			await action(cancellationToken);
			State = ViewState.Content;
			return true;
		}
		catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
		{
			State = ViewState.Cancelled;
			return false;
		}
		catch
		{
			State = ViewState.Error;
			throw;
		}
		finally
		{
			Volatile.Write(ref isRunning, 0);
		}
	}
}

static class Program
{
	public static async Task Main()
	{
		var controller = new AsyncActionController();
		using var cancellation = new CancellationTokenSource();

		var first = controller.ExecuteAsync(
			async token => await Task.Delay(50, token),
			cancellation.Token);
		var duplicateAccepted = await controller.ExecuteAsync(_ => Task.CompletedTask, CancellationToken.None);
		var firstAccepted = await first;

		if (!firstAccepted || duplicateAccepted || controller.State is not ViewState.Content)
		{
			throw new InvalidOperationException("비동기 상태 전환 검증에 실패했습니다.");
		}

		cancellation.Cancel();
		await controller.ExecuteAsync(token => Task.Delay(50, token), cancellation.Token);
		if (controller.State is not ViewState.Cancelled)
		{
			throw new InvalidOperationException("취소 상태 검증에 실패했습니다.");
		}

		Console.WriteLine("중복 방지와 Content/Cancelled 상태 전환을 검증했습니다.");
	}
}

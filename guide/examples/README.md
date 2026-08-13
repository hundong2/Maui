# C# 실습 프로젝트

MAUI workload 없이 .NET 10 console에서 비동기 UI command와 단일 state 전환 패턴을 연습한다.

```bash
dotnet run --project guide/examples/ToolkitGuide.Examples/ToolkitGuide.Examples.csproj
```

예제는 중복 실행을 거부하고 `CancellationToken`을 전달하며 `Idle → Loading → Content/Error/Cancelled` 흐름을 검사한다. 실제 MAUI ViewModel에서는 state를 bindable property로 노출하고 service 호출부를 Popup, Camera 또는 File API로 교체한다.

# .NET MAUI Community Toolkit

[English](README.md) | **한국어** | [한국어 학습 가이드](guide/README.md)

.NET MAUI Community Toolkit은 여러 .NET MAUI 앱에서 반복해서 구현하는 공통 요소를 모은 라이브러리다. .NET MAUI 앱을 만들 때 자주 필요한 작업을 단순화하고 올바른 구현 예시를 제공한다.

기능은 .NET 커뮤니티가 기여하고 핵심 maintainer가 관리한다. Toolkit에서 검증된 기능은 장차 공식 .NET MAUI 라이브러리로 승격될 수도 있다.

## 문서

`CommunityToolkit.Maui` 공식 문서는 [Microsoft Learn](https://learn.microsoft.com/dotnet/communitytoolkit/maui/get-started?tabs=CommunityToolkitMaui)에 있다. 저장소 구조, 실습과 고급 개발 방법은 [한국어 학습 가이드](guide/README.md)를 참고한다.

## 설치

안정 버전은 NuGet에서 설치한다.

```bash
dotnet add package CommunityToolkit.Maui
dotnet add package CommunityToolkit.Maui.MediaElement
dotnet add package CommunityToolkit.Maui.Maps
dotnet add package CommunityToolkit.Maui.Camera
```

필요한 package만 선택한다. 예를 들어 일반 converter와 behavior만 사용한다면 기본 package로 시작한다.

### Preview 설치

main branch preview는 GitHub Packages를 사용한다. classic personal access token에는 읽기만 필요하다면 `read:packages` 범위만 부여한다. token을 source URL이나 저장소 파일에 넣지 말고 사용자 수준 secret store 또는 환경 변수로 관리한다.

```bash
dotnet nuget add source https://nuget.pkg.github.com/CommunityToolkit/index.json \
  -n CommunityToolkitGitHubNuget \
  -u YOUR_GITHUB_USERNAME \
  -p YOUR_PERSONAL_ACCESS_TOKEN
```

원본 README에 표시된 preview version은 시간이 지나면 바뀔 수 있으므로 package feed에서 현재 version을 확인한다.

## 시작하기

`MauiProgram.cs`에서 Toolkit을 초기화한다.

```csharp
using CommunityToolkit.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		return builder.Build();
	}
}
```

XAML에서는 다음 namespace를 선언한다.

```xml
xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
```

MediaElement과 Camera처럼 별도 package인 기능은 해당 package의 builder 확장도 초기화해야 한다. 사용 중인 version의 analyzer 경고와 공식 문서를 확인한다.

## Roadmap과 기여

Toolkit은 community와 maintainer의 자발적 기여로 운영되므로 고정된 기능 제공 일정은 없다. 새 기능은 대략 다음 절차를 따른다.

1. Discussion에서 문제와 아이디어를 논의한다.
2. 구문·동작·장단점을 포함한 proposal issue를 제출한다.
3. core team champion이 제안을 검토 대상으로 올린다.
4. 과반 승인 후 구현한다.
5. test와 sample을 포함한 변경을 검토한다.
6. 별도 문서 저장소에도 공식 문서를 제출한다.
7. 구현과 문서가 승인되면 merge한다.

기여하기 전에 [CONTRIBUTING.md](CONTRIBUTING.md)와 [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct)를 읽는다. 기능 변경에는 test, sample과 documentation이 필요하며, bug report에는 최소 재현 repository를 제공한다.

## .NET Foundation

이 프로젝트는 [.NET Foundation](https://dotnetfoundation.org)의 지원을 받는다.

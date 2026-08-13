# .NET MAUI Community Toolkit 한국어 학습 가이드

작성일: 2026-08-13

## 학습 순서

1. [설치와 첫 사용](01_getting_started.md)
2. [핵심 기능과 앱 설계](02_core_features.md)
3. [저장소 구조와 개발](03_repository_development.md)
4. [성능·보안·배포와 확장](04_advanced.md)
5. [C# 실습 프로젝트](examples/README.md)

## Toolkit의 역할

.NET MAUI Community Toolkit은 converter, behavior, animation, layout, popup, drawing, file·folder service, speech, camera와 media 같은 공통 기능을 package 단위로 제공한다. 앱은 필요한 package만 참조하고 `MauiProgram`에서 builder extension을 호출한다.

## 지원 package

- `CommunityToolkit.Maui`: 핵심 view, behavior, converter, extension과 service
- `CommunityToolkit.Maui.MediaElement`: cross-platform media playback
- `CommunityToolkit.Maui.Camera`: camera preview와 capture
- `CommunityToolkit.Maui.Maps`: 지도 관련 기능

package별 초기화·permission·platform manifest 요구사항은 다르다. 기능을 추가할 때 NuGet 설치만으로 끝났다고 가정하지 않는다.

## 빠른 경로

```bash
dotnet workload install maui
dotnet new maui -n ToolkitDemo
cd ToolkitDemo
dotnet add package CommunityToolkit.Maui
```

그다음 `MauiProgram.cs`에 `.UseMauiCommunityToolkit()`을 추가하고 XAML namespace를 선언한다. 저장소 자체를 개발하려면 .NET 10 SDK와 MAUI workload가 필요하다.

## 학습 결과

가이드를 마치면 package 선택, builder 초기화, XAML 사용, 비동기 UI 작업의 취소·중복 방지, platform별 코드 탐색, unit test와 sample 추가, 배포 시 trimming/AOT 점검을 수행할 수 있다.

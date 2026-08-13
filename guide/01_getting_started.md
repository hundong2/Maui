# 01. 설치와 첫 사용

## 요구 사항

- 저장소 개발: `global.json` 기준 .NET SDK 10.0.100 이상 호환 feature band
- Android/iOS/macOS/Windows 대상에 맞는 .NET MAUI workload와 platform SDK
- Windows 앱 개발 시 Visual Studio의 MAUI workload 권장

설치 상태를 확인한다.

```bash
dotnet --info
dotnet workload list
```

## 최소 초기화

NuGet package를 설치하고 `MauiAppBuilder` chain에 `.UseMauiCommunityToolkit()`을 한 번만 추가한다. 초기화를 빠뜨리면 repository의 analyzer가 진단을 제공할 수 있다.

XAML 예시:

```xml
<ContentPage
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit">
    <Entry>
        <Entry.Behaviors>
            <toolkit:EmailValidationBehavior />
        </Entry.Behaviors>
    </Entry>
</ContentPage>
```

## 일반적인 문제

- type을 못 찾음: package 종류와 XAML namespace를 확인한다.
- analyzer 초기화 경고: 올바른 `UseMauiCommunityToolkit*` extension을 호출한다.
- platform build 실패: workload와 Android SDK/Xcode/Windows SDK를 확인한다.
- preview restore 401: GitHub Packages credential과 `read:packages` 범위를 확인한다. token을 commit하지 않는다.
- runtime permission 실패: camera, microphone, storage 같은 권한을 manifest와 runtime 양쪽에서 처리한다.

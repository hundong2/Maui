# 03. 저장소 구조와 개발

## 주요 디렉터리

- `src/CommunityToolkit.Maui`: 핵심 Toolkit 구현
- `src/CommunityToolkit.Maui.MediaElement`, `.Camera`: 별도 기능 package
- `src/*Analyzers`, `*SourceGenerators`: compile-time 진단과 code generation
- `src/*UnitTests`: xUnit 기반 unit test
- `samples/CommunityToolkit.Maui.Sample`: 기능별 sample 앱
- `build/`: packaging, signing과 workflow 자료

platform 공통 코드는 `.shared.cs`, platform 구현은 `.android.cs`, `.macios.cs`, `.windows.cs`, `.tizen.cs` 규칙을 사용한다. 새 기능은 기존 naming과 partial type 구조를 따른다.

## 빌드와 test

```bash
dotnet restore src/CommunityToolkit.Maui.slnx
dotnet build src/CommunityToolkit.Maui.slnx --no-restore
dotnet test src/CommunityToolkit.Maui.slnx --no-build
```

전체 solution은 platform workload와 SDK가 필요해 환경에 따라 일부 target이 제외될 수 있다. 작은 변경은 관련 project/test부터 실행하고 CI에서 전체 matrix를 확인한다.

## 기여 품질

새 기능에는 API 구현만 아니라 unit test, sample과 MicrosoftDocs repository의 문서가 필요하다. public API, trimming/AOT, nullable warning과 analyzer release note도 검토한다. repository는 tab indentation과 warning-as-error 정책을 사용한다.

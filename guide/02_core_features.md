# 02. 핵심 기능과 앱 설계

## Behavior와 Converter

Behavior는 view를 상속하지 않고 validation이나 event 반응을 부착한다. Converter는 binding 값의 표현을 바꾼다. 둘 다 UI state를 숨기는 장소로 남용하지 말고 business state는 ViewModel에 둔다.

## Popup

Popup은 결과를 반환하는 비동기 흐름으로 다룬다. page가 사라질 수 있으므로 `CancellationToken`을 전달하고 중복 호출을 막는다. navigation과 dialog orchestration을 service로 감싸면 ViewModel test가 쉬워진다.

## StateContainer와 Layout

loading, empty, error, content를 명시적인 state로 모델링한다. 여러 boolean을 조합하면 불가능한 상태가 생기므로 enum 또는 discriminated state에 가까운 model을 권장한다.

## MediaElement와 Camera

별도 package와 builder 초기화가 필요하다. 화면 lifecycle에 맞춰 resource를 해제하고 background 전환, permission 거절, device 부재와 stream 실패를 처리한다. emulator와 실제 device 결과가 다를 수 있다.

## 핵심 흐름

```text
사용자 동작 -> ViewModel async command -> service/toolkit API
           -> success/error/cancel 결과 -> 단일 UI state 갱신
```

[실습 프로젝트](examples/README.md)는 이 흐름을 MAUI workload 없이 C# console에서 검증한다.

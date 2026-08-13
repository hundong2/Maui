# 04. 성능·보안·배포와 확장

## 성능과 lifecycle

- event subscription과 native handler reference를 해제해 memory leak을 막는다.
- UI thread를 오래 점유하지 말고 I/O는 async로 실행한다.
- drawing, camera와 media는 allocation·frame time·device resource를 실제 장치에서 측정한다.
- 큰 collection에는 virtualization을 유지하고 converter에서 비싼 계산을 반복하지 않는다.

## AOT와 trimming

release build의 trimming과 Native AOT에서는 reflection 기반 접근이 제거될 수 있다. compiled binding, source generator와 명시적 보존 설정을 사용하고 release artifact를 각 platform에서 smoke test한다.

## 보안

- package credential과 signing key를 repository에 저장하지 않는다.
- file picker 결과를 신뢰하지 말고 type·size와 접근 범위를 검증한다.
- 외부 media URL에는 TLS, redirect와 허용 scheme 정책을 둔다.
- permission은 필요한 시점에 최소 범위로 요청하고 거절·영구 거절 UX를 제공한다.

## 확장 설계

공통 interface와 platform partial implementation을 분리하고, platform API는 handler/service 경계 뒤에 둔다. 새 public API는 취소, 오류, thread affinity, nullability와 backward compatibility를 명시한다.

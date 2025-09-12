using UnityEngine;

public class mover : MonoBehaviour
{
    // ── 기존 변수들 유지 ───────────────────────────────────────────────────────────────
    string ideltag;                               // ← 시작 시 태그 저장
    float triggertime = 0;                        // ← 미사용: 기존 그대로
    [SerializeField] float moveSpeed = 3f;        // ← 이동 속도
    [SerializeField] float jumpForce = 8f;        // ← 점프 힘
    [SerializeField] float rotateSpeed = 12f;     // ← 전진 시 회전 속도(부드럽게 돌아가게)

    Rigidbody rb;                                 // ← 점프용 리지드바디
    bool isGrounded;                              // ← 접지 여부 캐시

    void Start()
    {
        ideltag = gameObject.tag;                 // ← 시작 태그 저장
        PrintInstriction();                       // ← 디버그 문구 출력
        rb = GetComponent<Rigidbody>();           // ← Rigidbody 참조 캐시
    }

    void Update()
    {
        movePlayerCameraRelative();               // ← 카메라 기준 이동/회전 처리
        jump();                                   // ← 점프 처리(기존 유지)
    }

    void PrintInstriction()
    {
        Debug.Log("테스트123123");                // ← 테스트 로그
    }

    // ── 핵심: 카메라 기준 이동/회전 ───────────────────────────────────────────────────
    void movePlayerCameraRelative()
    {
        // 1) 입력값(전/후, 좌/우)을 읽어온다. (Raw로 각 방향 -1/0/1)
        float x = Input.GetAxis("Horizontal");    // ← A/D, 좌/우
        float z = Input.GetAxis("Vertical");      // ← W/S, 전/후

        // 2) 메인 카메라를 가져온다. (FreeLook은 메인 카메라를 구동하므로 Camera.main 사용)
        Camera cam = Camera.main;                 // ← 활성 메인 카메라
        if (cam == null) return;                  // ← 카메라가 없으면 아무 것도 하지 않음

        // 3) 카메라의 전방/우측 벡터에서 '수직 성분(Y)'을 제거해 수평면에 투영한다.
        Vector3 camForward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up).normalized; // ← 카메라 앞(수평 성분)
        Vector3 camRight   = Vector3.ProjectOnPlane(cam.transform.right,   Vector3.up).normalized; // ← 카메라 오른쪽(수평 성분)

        // 4) 입력을 카메라 기준으로 합성해 '이동 방향'을 만든다.
        Vector3 moveDir = (camForward * z + camRight * x);  // ← W/S는 camForward, A/D는 camRight

        // 5) 실제 이동: 월드 좌표계 기준으로 Translate (점프와 간섭하지 않음)
        if (moveDir.sqrMagnitude > 0.0001f)                  // ← 입력이 있을 때만 이동
        {
            Vector3 step = moveDir.normalized * moveSpeed * Time.deltaTime; // ← 정규화 후 프레임 독립 속도
            transform.Translate(step, Space.World);           // ← 월드 기준으로 이동(카메라 기준 방향 유지)

            // 6) 전진 중에는 '이동 방향'을 바라보도록 부드럽게 회전시킨다.
            Quaternion targetRot = Quaternion.LookRotation(moveDir.normalized, Vector3.up); // ← 바라볼 회전(위축=월드 Y)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime); // ← 부드러운 회전
        }
        // *원한다면: 입력이 없어도 항상 플레이어를 '카메라 전방'으로 맞추고 싶다면 else에서 회전만 유지하도록 추가 가능
    }

    // ── 점프(기존 유지) ────────────────────────────────────────────────────────────────
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)   // ← 스페이스 & 접지 시
        {
            Vector3 v = rb.linearVelocity;                         // ← 현재 속도
            v.y = 0f;                                        // ← 수직 속도 리셋(일관된 점프 높이)
            rb.linearVelocity = v;                                  // ← 리셋 반영
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ← 위로 순간 힘
            isGrounded = false;                               // ← 공중 상태
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))       // ← Ground 태그와 닿으면
        {
            isGrounded = true;                                // ← 접지
        }
    }
}

 



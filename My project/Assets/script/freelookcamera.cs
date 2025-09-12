using UnityEngine;
using Unity.Cinemachine;  // ← CM3 네임스페이스

public class FaceFreeLook_CM3 : MonoBehaviour
{
    [SerializeField] CinemachineCamera cmCam;  // CM3 가상카메라
    [SerializeField] Transform playerBody;     // 회전시킬 본체
    [SerializeField] float smoothTime = 0.1f;  // 보간 시간
    float yawVel;

    void LateUpdate()
    {
        // CM3도 결국 메인 카메라를 구동하므로, 최종 시점은 Main Camera에서 읽는게 가장 안전
        if (Camera.main == null) return;
        float camYaw = Camera.main.transform.eulerAngles.y;                  // ← 최종 요
        float curYaw = playerBody.eulerAngles.y;
        float smoothed = Mathf.SmoothDampAngle(curYaw, camYaw, ref yawVel, smoothTime);
        playerBody.rotation = Quaternion.Euler(0f, smoothed, 0f);
    }
}

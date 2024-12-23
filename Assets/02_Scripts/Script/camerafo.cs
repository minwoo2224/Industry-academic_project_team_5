using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // 따라다닐 Player
    public Vector3 offset;   // 카메라의 위치 오프셋 (캐릭터와의 거리)
    public float smoothSpeed = 0.125f; // 카메라 이동 속도

    void LateUpdate()
    {
        if (player != null)
        {
            // 카메라의 목표 위치 계산 (캐릭터 중심 + 오프셋)
            Vector3 desiredPosition = player.position + offset;
            desiredPosition.z = transform.position.z; // Z축 고정

            // 부드럽게 이동 (Lerp로 이동)
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

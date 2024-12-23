using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // ����ٴ� Player
    public Vector3 offset;   // ī�޶��� ��ġ ������ (ĳ���Ϳ��� �Ÿ�)
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�

    void LateUpdate()
    {
        if (player != null)
        {
            // ī�޶��� ��ǥ ��ġ ��� (ĳ���� �߽� + ������)
            Vector3 desiredPosition = player.position + offset;
            desiredPosition.z = transform.position.z; // Z�� ����

            // �ε巴�� �̵� (Lerp�� �̵�)
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

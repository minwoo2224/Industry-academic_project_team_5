using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    // 파라미터 이름 상수로 선언 (오타 방지)
    private static readonly string IsRunningParam = "isRunning";
    private bool hasIsRunningParam = false; // isRunning 파라미터 존재 여부

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Animator가 연결되지 않았습니다. Player 오브젝트를 확인하세요.");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D가 연결되지 않았습니다. Player 오브젝트를 확인하세요.");
        }

        // Animator에 isRunning 파라미터가 있는지 확인
        hasIsRunningParam = animator != null && HasAnimatorParameter(IsRunningParam);
        if (!hasIsRunningParam)
        {
            Debug.LogError($"Animator에 '{IsRunningParam}' 파라미터가 존재하지 않습니다. Animator를 확인하세요.");
        }
    }

    void FixedUpdate()
    {
        // 좌우 이동 입력 받기
        movement.x = Input.GetAxis("Horizontal");

        // 실제 물리 이동 처리
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        // Animator 파라미터 제어
        if (hasIsRunningParam)
        {
            animator.SetBool(IsRunningParam, movement.x != 0); // 움직임 여부로 애니메이션 전환
        }
        // 캐릭터 방향 전환
        if (movement.x > 0) // 오른쪽 이동
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (movement.x < 0) // 왼쪽 이동
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // Animator 파라미터가 존재하는지 확인하는 유틸리티 메서드
    private bool HasAnimatorParameter(string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
            {
                return true;
            }
        }
        return false;
    }
}

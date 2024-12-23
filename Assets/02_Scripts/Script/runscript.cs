using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ�
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    // �Ķ���� �̸� ����� ���� (��Ÿ ����)
    private static readonly string IsRunningParam = "isRunning";
    private bool hasIsRunningParam = false; // isRunning �Ķ���� ���� ����

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Animator�� ������� �ʾҽ��ϴ�. Player ������Ʈ�� Ȯ���ϼ���.");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D�� ������� �ʾҽ��ϴ�. Player ������Ʈ�� Ȯ���ϼ���.");
        }

        // Animator�� isRunning �Ķ���Ͱ� �ִ��� Ȯ��
        hasIsRunningParam = animator != null && HasAnimatorParameter(IsRunningParam);
        if (!hasIsRunningParam)
        {
            Debug.LogError($"Animator�� '{IsRunningParam}' �Ķ���Ͱ� �������� �ʽ��ϴ�. Animator�� Ȯ���ϼ���.");
        }
    }

    void FixedUpdate()
    {
        // �¿� �̵� �Է� �ޱ�
        movement.x = Input.GetAxis("Horizontal");

        // ���� ���� �̵� ó��
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        // Animator �Ķ���� ����
        if (hasIsRunningParam)
        {
            animator.SetBool(IsRunningParam, movement.x != 0); // ������ ���η� �ִϸ��̼� ��ȯ
        }
        // ĳ���� ���� ��ȯ
        if (movement.x > 0) // ������ �̵�
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (movement.x < 0) // ���� �̵�
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // Animator �Ķ���Ͱ� �����ϴ��� Ȯ���ϴ� ��ƿ��Ƽ �޼���
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

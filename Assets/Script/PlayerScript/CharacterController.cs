using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed = 2f;
    public Vector2 lastMovementVector;
    Vector2 motionVector;
    Animator animator;
    public bool moving;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            horizontal,
            vertical);

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (horizontal != 0 || vertical != 0)
        {
            lastMovementVector = new Vector2(
                horizontal,
                vertical
            ).normalized;

            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2d.linearVelocity = motionVector * speed;
    }
}
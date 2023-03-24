using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;
    public bool isJumpBonus;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public SpriteRenderer spriteRenderer;
    public Sprite skin;
    public Sprite renaissancePlayerSprite;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        isJumpBonus = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButton("Jump") && (isGrounded || isJumpBonus) && spriteRenderer.sprite == (skin ||renaissancePlayerSprite ))
        {
            isJumping = true;
        }

        if (skin ||renaissancePlayerSprite )
        {
            MovePlayer(horizontalMovement);
            Flip(rb.velocity.x);
        }
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}

using Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement: MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private void Awake()
    {
        body= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        boxCollider= GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if (wallJumpCooldown > 0.2f)
        {
            
            body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
            if (Wall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (Wall() && !isGrounded())
        {
            if(horizontalInput==0)
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(body.linearVelocity.x*10), 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.linearVelocity = new Vector2(-Mathf.Sign(body.linearVelocity.x), 6);

            wallJumpCooldown = 0;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return rayCastHit.collider!=null;
    }

    private bool Wall()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return rayCastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !Wall();
    }
}

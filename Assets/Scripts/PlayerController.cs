using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float slopeFactor = 2f;
    public float dashForce = 5f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private bool isGrounded;

    public Animator anim;
    public float maxTiltAngle = 50f;
    
    public int health = 1;
    private bool isDead = false;
    private bool deadAnimFirst = true;

    public Animator gameOverAnim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isDead)
        {
            // Dash (X gomb)
            if (Input.GetKeyDown(KeyCode.X))
            {
                //Debug.Log("isGrounded: " + isGrounded);
                if (isGrounded)
                {
                    rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    anim.Play("PlayerPush");
                }
            }

            // Jump (Space gomb)
            if ((Input.GetKeyDown(KeyCode.Space) || IsMobileJump()) && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false; // hogy ne lehessen dupla ugrani
            }
        }else if (deadAnimFirst)
        {
            Time.timeScale = 0f;
            anim.Play("PlayerEnd");
            if (gameOverAnim != null)
            {
                gameOverAnim.Play("endCanvasAnim");
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<Data>().SaveData();

            }
            deadAnimFirst = false;
        }
    }

    bool IsMobileJump()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Began;
        }
        return false;
    }

    void FixedUpdate()
    {
        if (!isDead)
        {

            if (isGrounded)
            {
                float slopeAngle = GetGroundSlopeAngle();
                float speed = baseSpeed + slopeFactor * Mathf.Sin(slopeAngle * Mathf.Deg2Rad);
                rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            }
            ClampZRotation();
        }
    }
    void ClampZRotation()
    {
        float z = transform.eulerAngles.z;

        // Átalakítás -180 és 180 közé, hogy működjön a ± szög
        if (z > 180f) z -= 360f;

        z = Mathf.Clamp(z, -maxTiltAngle, maxTiltAngle);

        transform.rotation = Quaternion.Euler(0f, 0f, z);
    }

    float GetGroundSlopeAngle()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);
        if (hit.collider != null)
        {
            Vector2 normal = hit.normal;
            float angle = Vector2.Angle(normal, Vector2.up);
            return angle;
        }
        return 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Csak a "Ground" tag-gel rendelkez� objektumokon legyen grounded
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Ground2"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || (collision.collider.CompareTag("Ground2")))
        {
            isGrounded = false;
        }
    }

    public void GetDamage()
    {
        health--;
        if(health == 0)
        {
            isDead = true;
        }
    }
}

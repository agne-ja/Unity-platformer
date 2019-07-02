using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed = 5f;
    public float jumpPower = 10f;
    public Animator anim;


    public Transform groundCheck;
    public float groundCheckRadius;

    private bool isGrounded;
    public LayerMask whatIsGround;

    public GameController GC;
    public GameObject WinPanel;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        anim.SetFloat("isWalking", Mathf.Abs(horizontal));
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

        if ((horizontal < -0.1f && transform.localScale.x > 0) || (horizontal > 0.1f && transform.localScale.x < 0))
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("isGrounded", isGrounded);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.name == "Finish") && (GC.Kills == GC.requredKills))
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0;
            
        }
        else if(other.CompareTag("Coin"))
        {
            GC.score+=10;
            Destroy(other.gameObject);
        }
    }
}

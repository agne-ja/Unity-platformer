using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public float xMax;
    public float xMin;
    public Animator anim;

    public GameController GC;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if ((transform.position.x >= xMax) || (transform.position.x <= xMin) )
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed = -speed;
            transform.position += new Vector3(speed / 600, 0, 0);
        }

        rb2d.velocity = new Vector2(speed * Time.deltaTime, 0);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject.GetComponent<Collider2D>());
            anim.SetBool("killed", true);
            GC.Kills++;
            Destroy(gameObject, 1.5f);
        }
    }
}

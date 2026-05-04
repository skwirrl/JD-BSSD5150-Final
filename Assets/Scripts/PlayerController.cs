using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, 0);

        // tell the animator whether we're moving
        anim.SetBool("isRunning", Mathf.Abs(moveX) > 0.1f);

        // flip sprite to face movement direction
        if (moveX > 0.1f)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (moveX < -0.1f)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        // clamp to screen edges
        Vector3 pos = transform.position;
        float left = Camera.main.ViewportToWorldPoint(Vector3.zero).x + 0.5f;
        float right = Camera.main.ViewportToWorldPoint(Vector3.right).x - 0.5f;
        pos.x = Mathf.Clamp(pos.x, left, right);
        transform.position = pos;
    }

    // fires when a trigger-collider overlaps this object's collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Part")
        {
            GameController gc = FindAnyObjectByType<GameController>();
            gc.PartCaught();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Junk")
        {
            GameController gc = FindAnyObjectByType<GameController>();
            gc.LoseLife();
            Destroy(collision.gameObject);
        }
    }
}
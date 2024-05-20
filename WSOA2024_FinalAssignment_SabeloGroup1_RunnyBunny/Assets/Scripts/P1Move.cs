using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Move : MonoBehaviour
{
    public float MovementSpeed = 5f;

    public float BounceUpForce = 5f;

    public float BounceLeftForce = 5f;

    public float JumpForce = 1f;

    Rigidbody2D rb;

    //public GameObject Player;

    public Vector2 CalculateDirection()
    {
        Vector2 Direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            Direction.x -= 1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Direction.x += 1.0f;
        }

        return Direction.normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = CalculateDirection();

        transform.Translate(direction * MovementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            rb.AddForce(Vector2.left * BounceLeftForce, ForceMode2D.Impulse);

            rb.AddForce(Vector2.up * BounceUpForce, ForceMode2D.Impulse);

            Debug.Log("Hit");
        }
    }
}

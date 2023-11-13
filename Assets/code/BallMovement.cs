using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    Vector2 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        // rigidbody.AddForce(new Vector2(0f, 1f)); 
        // rigidbody.velocity = new Vector2(10, 10);
        rigidbody.AddForce(new Vector2(50, 50));
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rigidbody.velocity = direction * Mathf.Max(speed, 0f);
    }
}

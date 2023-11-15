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
        rigidbody.AddForce(new Vector2(50, 50));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastVelocity = rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);
        rigidbody.velocity = direction * speed;
    }
}

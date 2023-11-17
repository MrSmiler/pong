using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public const int speed = 50;
    new Rigidbody2D rigidbody;
    Vector2 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        UnityEngine.Random.InitState((int)DateTime.UtcNow.Ticks);
        float x = UnityEngine.Random.Range(0f, 1f);
        float y = UnityEngine.Random.Range(0f, 1f);
        Debug.Log("random x: " + x + " y:" + y);
        float xVelocity = x * speed;
        float yVelocity = y * speed;
        rigidbody.AddForce(new Vector2(xVelocity, yVelocity));
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
        Debug.Log("Reflect direction: " + direction);
        rigidbody.velocity = direction * speed;
    }
}

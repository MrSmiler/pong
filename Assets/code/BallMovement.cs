using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public const int speed = 50;
    Rigidbody2D rigidbody;
    Vector2 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        UnityEngine.Random.InitState((int)DateTime.UtcNow.Ticks);
        int[] unit = { -1, 1 };
        int i = UnityEngine.Random.Range(0, 2);
        int j = UnityEngine.Random.Range(0, 2);
        float xVelocity = unit[i] * speed;
        float yVelocity = unit[j] * speed;
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

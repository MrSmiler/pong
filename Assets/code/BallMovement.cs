using System;
using UnityEngine;
using UnityEngine.Audio;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;
    Rigidbody2D rigidbody;
    Vector2 lastVelocity;

    private AudioSource audio;
    // Start is called before the first frame update
    private void Awake()
    {
        if (speed == 0)
        {
            throw new Exception("speed should not be equal to zero");
        }
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

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
        audio.Play();
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);
        rigidbody.velocity = direction * speed;
    }
}

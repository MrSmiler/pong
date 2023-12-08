using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private int _speed;
    private Rigidbody2D _rigidbody;
    private Vector2 _lastVelocity;

    private AudioSource _audio;
    // Start is called before the first frame update
    private void Awake()
    {
        if (_speed == 0)
        {
            throw new Exception("speed should not be equal to zero");
        }
    }

    public void Test()
    {
        Debug.Log("ok");
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();

        UnityEngine.Random.InitState((int)DateTime.UtcNow.Ticks);
        int[] unit = { -1, 1 };
        int i = UnityEngine.Random.Range(0, 2);
        int j = UnityEngine.Random.Range(0, 2);
        float xVelocity = unit[i] * _speed;
        float yVelocity = unit[j] * _speed;
        _rigidbody.AddForce(new Vector2(xVelocity, yVelocity));
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _lastVelocity = _rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audio.Play();
        float speed = _lastVelocity.magnitude;
        Vector2 direction = Vector2.Reflect(_lastVelocity.normalized, collision.GetContact(0).normal);
        _rigidbody.velocity = direction * speed;
    }
}

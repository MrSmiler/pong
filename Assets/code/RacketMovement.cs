using UnityEngine;

public class RacketMovement : MonoBehaviour
{

    private Rigidbody2D _rigidBody;
    private const float _velocity = 10f;
    protected float moveDirection;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        moveDirection = 0f;
    }

    private void FixedUpdate()
    {
        var position = _rigidBody.position;
        position.y += moveDirection * Time.deltaTime * _velocity;
        _rigidBody.MovePosition(position);
    }
}

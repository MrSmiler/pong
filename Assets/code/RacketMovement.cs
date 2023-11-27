using UnityEngine;

public class RacketMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private float velocity = 100f;
    protected float moveDirection;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveDirection = 0f;
    }

    void Update()
    {
        Vector2 position = rigidBody.position;
        position.y += moveDirection * Time.deltaTime * velocity;
        rigidBody.MovePosition(position);
    }
}

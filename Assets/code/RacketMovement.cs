using Game.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private float velocity = 100f;
    private float moveDirection;

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

    public void OnMove(ref RacketMoveInputEvent data)
    {
        moveDirection = data.direction;
    }

    private void OnEnable()
    {
        GameEventManager.GetInputEventBus().SubscribeTo<RacketMoveInputEvent>(OnMove); 
    }
    private void OnDisable()
    {
        GameEventManager.GetInputEventBus().UnsubscribeFrom<RacketMoveInputEvent>(OnMove); 
    }

}

using Game.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BallSpawner : MonoBehaviour
{
    private GameObject ballPrefab;

    private void Start()
    {
        ballPrefab = Addressables.LoadAssetAsync<GameObject>("BallPrefab").WaitForCompletion();
        SpawnBall();    
    }

    private void OnEnable()
    {
        GameEventManager.GetGameEventBus().SubscribeTo<RightGoalTriggerdEvent>(RightGoalTriggerd); 
        GameEventManager.GetGameEventBus().SubscribeTo<LeftGoalTriggerdEvent>(LeftGoalTriggerd); 
    }
    private void OnDisable()
    {
        GameEventManager.GetGameEventBus().UnsubscribeFrom<RightGoalTriggerdEvent>(RightGoalTriggerd); 
        GameEventManager.GetGameEventBus().UnsubscribeFrom<LeftGoalTriggerdEvent>(LeftGoalTriggerd); 
    }

    void RightGoalTriggerd(ref RightGoalTriggerdEvent eventData)
    {
        Destroy(eventData.ballGameObject);
        SpawnBall();
    }
    void LeftGoalTriggerd(ref LeftGoalTriggerdEvent eventData)
    {
        Destroy(eventData.ballGameObject);
        SpawnBall();
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform);
        if (ball != null)
        {
            Debug.Log("Ball instantiated");
        }
        else
        {
            Debug.Log("Ball failed to instantiated");
        }
    }
}

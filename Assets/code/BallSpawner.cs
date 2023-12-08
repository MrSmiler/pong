using Game.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BallSpawner : MonoBehaviour
{
    private GameObject _ballPrefab;

    private void Start()
    {
        _ballPrefab = Addressables.LoadAssetAsync<GameObject>("BallPrefab").WaitForCompletion();
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

    private void RightGoalTriggerd(ref RightGoalTriggerdEvent eventData)
    {
        Destroy(eventData.ballGameObject);
        SpawnBall();
    }

    private void LeftGoalTriggerd(ref LeftGoalTriggerdEvent eventData)
    {
        Destroy(eventData.ballGameObject);
        SpawnBall();
    }

    private void SpawnBall()
    {
        var ball = Instantiate(_ballPrefab, transform);
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

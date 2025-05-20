using BrickBreaker.Ball.Factory;
using UnityEngine;

public class BallFactoryInitialize : MonoBehaviour
{
    [SerializeField] private BallFactoryData _ballFactoryData;

    private void Awake()
    {
        BallFactory.Initialize(_ballFactoryData);
    }
}

using BrickBreaker.Ball.Factory;
using BrickBreaker.Ball.Type;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private BallType _ballType;
    [SerializeField] private Transform _ballSpwanPoint;
    void Start()
    {
        BallFactory.CreateBall(_ballType, _ballSpwanPoint.position);       
    }
}

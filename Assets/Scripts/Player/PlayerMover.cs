using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxRight;
    [SerializeField] private float _maxLeft;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _maxRight)
        {
            SetNextPosition(_stepSize);
        }
    }

    public void TryMoveLeft()
    {
        if (_targetPosition.x > _maxLeft)
        {
            SetNextPosition(-_stepSize);
        }
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x + stepSize, _targetPosition.y, _targetPosition.z);
    }
}

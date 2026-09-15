using UnityEngine;

public class PatrolState : IEnemyState
{
    private Transform[] _wayPoints;
    private int _currentWayPointIndex;
    private Transform _currentWayPoint;

    private Enemy _enemy;

    public PatrolState(Enemy enemy, Transform[] wayPoints)
    {
        _enemy = enemy;
        _wayPoints = wayPoints;
    }

    public void Enter()
    {
        _currentWayPointIndex = 0;
        _currentWayPoint = _wayPoints[0];

        MoveToWayPoint(_currentWayPoint);
    }

    public void Exit()
    {

    }

    public void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (Vector3.Distance(_enemy.transform.position , _currentWayPoint.position) > 2f)
        {
            return;
        }

        _currentWayPointIndex++;
        _currentWayPoint = _wayPoints[_currentWayPointIndex % _wayPoints.Length];

        MoveToWayPoint(_currentWayPoint);
    }

    private void MoveToWayPoint(Transform wayPoint)
    {
        _enemy.NavMeshAgent.destination = wayPoint.position;
    }
}

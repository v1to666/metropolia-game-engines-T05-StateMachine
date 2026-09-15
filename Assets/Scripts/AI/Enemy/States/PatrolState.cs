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
        _enemy.MeshRenderer.material.color = Color.blue;

        _currentWayPointIndex = 0;
        _currentWayPoint = _wayPoints[0];

        _enemy.NavMeshAgent.isStopped = false;

        MoveToWayPoint(_currentWayPoint);
    }

    public void Exit()
    {

    }

    public void Update()
    {

        Collider[] colliders = Physics.OverlapSphere(_enemy.transform.position, 5f);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                _enemy.EnemyStateMachine.ChangeState(new AlertState(_enemy, player));

                return;
            }
        }

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

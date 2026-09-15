using UnityEngine;

public class ChaseState : IEnemyState
{
    private Enemy _enemy;
    private Player _player;

    private float _timer = 0f;

    public ChaseState(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void Enter()
    {
        _enemy.MeshRenderer.material.color = Color.red;

        _enemy.NavMeshAgent.isStopped = false;

        _enemy.NavMeshAgent.speed = 8f;
    }

    public void Exit()
    {

    }

    public void Update()
    {
        _enemy.NavMeshAgent.destination = _player.transform.position;

        float searchTime = 3f;

        if (_timer < searchTime)
        {
            _timer += Time.deltaTime;

            return;
        }

        _enemy.EnemyStateMachine.ChangeState(new AlertState(_enemy, _player));
    }
}

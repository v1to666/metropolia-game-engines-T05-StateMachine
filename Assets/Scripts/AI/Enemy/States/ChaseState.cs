using UnityEngine;

public class ChaseState : IEnemyState
{
    private Enemy _enemy;
    private Player _player;

    public ChaseState(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void Enter()
    {
        _enemy.MeshRenderer.material.color = Color.red;

        _enemy.NavMeshAgent.isStopped = false;

        _enemy.NavMeshAgent.speed = 5f;
    }

    public void Exit()
    {

    }

    public void Update()
    {
        _enemy.NavMeshAgent.destination = _player.transform.position;
    }
}

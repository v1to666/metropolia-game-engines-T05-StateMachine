using UnityEngine;

public class AlertState : IEnemyState
{
    private Enemy _enemy;
    private Player _player;

    private float _timer = 0f;

    public AlertState(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void Enter()
    {
        _enemy.MeshRenderer.material.color = Color.yellow;

        _enemy.NavMeshAgent.isStopped = true;
    }

    public void Exit()
    {

    }

    public void Update()
    {
        _enemy.transform.LookAt(_player.transform.position);

        Search();
    }

    private void Search()
    {
        float searchTime = 3f;

        if (_timer < searchTime)
        {
            _timer += Time.deltaTime;

            return;
        }

        Collider[] colliders = Physics.OverlapSphere(_enemy.transform.position, 5f);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                _enemy.EnemyStateMachine.ChangeState(new ChaseState(_enemy, player));

                return;
            }
        }

        _enemy.EnemyStateMachine.ChangeState(_enemy.PatrolState);
    }
}
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
        _enemy.MeshRenderer.material.color = new Color32(244, 67, 54, 255);

        _enemy.NavMeshAgent.isStopped = false;

        _enemy.NavMeshAgent.speed = 7f;
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

            Collider[] colliders = Physics.OverlapSphere(_enemy.transform.position, 8f);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<Player>(out Player player))
                {
                    _timer = 0f;
                }
            }

            return;
        }

        _enemy.EnemyStateMachine.ChangeState(new TrackState(_enemy, _player));
    }
}

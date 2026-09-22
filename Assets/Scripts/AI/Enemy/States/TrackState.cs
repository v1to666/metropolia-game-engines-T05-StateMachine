using UnityEngine;

public class TrackState : IEnemyState
{
    private Enemy _enemy;
    private Player _player;
    private Vector3 _playerLastPosition;

    public TrackState(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
        _playerLastPosition = player.transform.position;
    }

    public void Enter()
    {
        _enemy.MeshRenderer.material.color = new Color32(156, 39, 176, 255);

        _enemy.NavMeshAgent.destination = _playerLastPosition;

        _enemy.NavMeshAgent.speed = 3f;
    }

    public void Update()
    {
        if (Vector3.Distance(_enemy.transform.position, _playerLastPosition) < 1f)
        {
            _enemy.EnemyStateMachine.ChangeState(new AlertState(_enemy, _player));
        }

        Collider[] colliders = Physics.OverlapSphere(_enemy.transform.position, 5f);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                _enemy.EnemyStateMachine.ChangeState(new AlertState(_enemy, player));

                return;
            }
        }
    }

    public void Exit()
    {

    }
}

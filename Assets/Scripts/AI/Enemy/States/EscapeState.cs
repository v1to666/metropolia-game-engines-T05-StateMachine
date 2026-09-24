using UnityEngine;

public class EscapeState : IEnemyState
{
    private Enemy _enemy;
    private Player _player;

    private float _escapeTimer;

    public EscapeState(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void Enter()
    {
        _escapeTimer = 5f;

        _enemy.MeshRenderer.material.color = new Color32(33, 150, 243, 255);
    }

    public void Exit()
    {

    }

    public void Update()
    {
        _enemy.NavMeshAgent.destination = _enemy.transform.position - (_player.transform.position - _enemy.transform.position).normalized;

        if (_escapeTimer <= 0f)
        {
            _enemy.EnemyStateMachine.ChangeState(new AlertState(_enemy, _player));
        }

        Collider[] colliders = Physics.OverlapSphere(_enemy.transform.position, 5f);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Weapon>(out Weapon weapon))
            {
                _escapeTimer = 5f;

                return;
            }
        }

        _escapeTimer -= Time.deltaTime;
    }
}

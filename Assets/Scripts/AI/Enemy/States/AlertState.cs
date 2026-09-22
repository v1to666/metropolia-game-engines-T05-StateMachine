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
        _enemy.MeshRenderer.material.color = new Color32(255, 193, 7, 255);

        _enemy.NavMeshAgent.isStopped = true;
    }

    public void Exit()
    {
        _enemy.NavMeshAgent.isStopped = false;
    }

    public void Update()
    {
        Search();
    }

    private void Search()
    {
        float searchTime = 5f;

        _enemy.transform.Rotate(Vector3.up * 100f * Time.deltaTime);

        RaycastHit[] raycastHits = Physics.RaycastAll(_enemy.transform.position, _enemy.transform.forward, 5f);

        foreach (RaycastHit raycastHit in raycastHits)
        {
            if (raycastHit.collider.TryGetComponent<Player>(out Player player))
            {
                _enemy.EnemyStateMachine.ChangeState(new ChaseState(_enemy, player));

                return;
            }
        }

        if (_timer < searchTime)
        {
            _timer += Time.deltaTime;

            return;
        }

        _enemy.EnemyStateMachine.ChangeState(_enemy.PatrolState);
    }
}
using UnityEngine;

public class ChaseState : IEnemyState
{
    private Enemy _enemy;

    public ChaseState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}

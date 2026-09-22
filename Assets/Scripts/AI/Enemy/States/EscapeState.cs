using UnityEngine;

public class EscapeState : IEnemyState
{
    private Enemy _enemy;

    public EscapeState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        _enemy.MeshRenderer.material.color = new Color32(33, 150, 243, 255);
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }
}

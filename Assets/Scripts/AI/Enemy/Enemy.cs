using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _wayPoints;

    private EnemyStateMachine _stateMachine;

    private PatrolState _patrolState;
    private ChaseState _chaseState;

    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private void Awake()
    {
        _stateMachine = new EnemyStateMachine();

        _patrolState = new PatrolState(this, _wayPoints);
        _chaseState = new ChaseState(this);
    }

    private void Start()
    {
        _stateMachine.ChangeState(_patrolState);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}

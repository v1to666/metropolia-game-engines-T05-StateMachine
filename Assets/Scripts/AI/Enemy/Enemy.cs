using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _wayPoints;

    private EnemyStateMachine _stateMachine;

    public PatrolState PatrolState {  get; private set; }

    public MeshRenderer MeshRenderer => _meshRenderer;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public EnemyStateMachine EnemyStateMachine => _stateMachine;

    private void Awake()
    {
        _stateMachine = new EnemyStateMachine();

        PatrolState = new PatrolState(this, _wayPoints);
    }

    private void Start()
    {
        _stateMachine.ChangeState(PatrolState);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 5f);
    }
}

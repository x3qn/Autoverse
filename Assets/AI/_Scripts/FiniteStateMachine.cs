using UnityEngine;
using UnityEngine.AI;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField]
    StateBehaviour currentState;
    [SerializeField]
    NavMeshAgent myAgent;

    [Header("Target Settings")]
    //[SerializeField]
    //LayerMask targetLayers;
    [SerializeField]
    Transform playerTest;

    [SerializeField]
    IdleState myIdleState;
    [SerializeField]
    HuntingState myHuntingState;
    [SerializeField]
    AttackState myAttackState;

    Transform currentTarget;

    public IdleState MyIdleState => myIdleState;
    public HuntingState MyHuntingState => myHuntingState;
    public AttackState MyAttackState => myAttackState;

    public NavMeshAgent MyAgent => myAgent;
    public Transform CurrentTarget => currentTarget;
    //public LayerMask TargetLayers => targetLayers;

    public Transform PlayerTest => playerTest;

    private void Start()
    {
        currentState.StateEnter();
    }

    void Update()
    {
        currentState.StateUpdate(Time.deltaTime);
    }

    public void SwitchState(StateBehaviour newState)
    {
        currentState.StateExit();
        currentState = newState;
        currentState.StateEnter();
    }

    public StateBehaviour GetCurrentState()
    {
        return currentState;
    }

    public void SetTarget(Transform target)
    {
        currentTarget = target;
    }
}

//{
//    [SerializeField]
//    StateBehaviour currentState;
//    [SerializeField]
//    NavMeshAgent myAgent;
//    [SerializeField]
//    Transform playerTransform;


//    [SerializeField]
//    IdleState myIdleState;
//    [SerializeField]
//    HuntingState myHuntingState;
//    [SerializeField]
//    AttackState myAttackState;

//    public IdleState MyIdleState { get => myIdleState; }
//    public HuntingState MyHuntingState { get => myHuntingState; }
//    public AttackState MyAttackState { get => myAttackState; }


//    public NavMeshAgent MyAgent { get => myAgent; }
//    public Transform PlayerTransform { get => playerTransform; }

//    private void Start()
//    {
//        currentState.StateEnter();
//    }
//    void Update()
//    {
//        currentState.StateUpdate(Time.deltaTime);
//    }
//    public void SwitchState(StateBehaviour newState)
//    {
//        currentState.StateExit();
//        currentState = newState;
//        currentState.StateEnter();
//    }

//    public StateBehaviour GetCurrentState() //fuer animator
//    {
//        return currentState;
//    }
//}

using UnityEngine;
using UnityEngine.AI;


public class FiniteStateMachineArcher : MonoBehaviour
{
    [SerializeField]
    StateBehaviourArcher currentState;
    [SerializeField]
    NavMeshAgent myAgent;

    [Header("Target Settings")]
    //[SerializeField]
    //LayerMask targetLayers;
    [SerializeField]
    Transform playerTest;

    [SerializeField]
    IdleStateArcher myIdleState;
    [SerializeField]
    AttackStateArcher myAttackState;

    Transform currentTarget;

    public IdleStateArcher MyIdleState => myIdleState;
    public AttackStateArcher MyAttackState => myAttackState;

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

    public void SwitchState(StateBehaviourArcher newState)
    {
        currentState.StateExit();
        currentState = newState;
        currentState.StateEnter();
    }

    public StateBehaviourArcher GetCurrentState()
    {
        return currentState;
    }

    public void SetTarget(Transform target)
    {
        currentTarget = target;
    }
}


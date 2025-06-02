using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private FiniteStateMachine fsm;
    [SerializeField]
    private UnityEngine.AI.NavMeshAgent agent;

    private readonly int SpeedHash = Animator.StringToHash("Speed");
    private readonly int IsIdleHash = Animator.StringToHash("IsIdle");
    private readonly int IsRunningHash = Animator.StringToHash("IsRunning");

    void Awake()
    {
        animator = GetComponent<Animator>();
        fsm = GetComponent<FiniteStateMachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat(SpeedHash, speed);

        // Wenn du separate Booleans hast:
        if (fsm.MyIdleState == fsm.GetCurrentState())
        {
            animator.SetBool(IsIdleHash, true);
            animator.SetBool(IsRunningHash, false);
        }
        else if (fsm.MyHuntingState == fsm.GetCurrentState())
        {
            animator.SetBool(IsIdleHash, false);
            animator.SetBool(IsRunningHash, true);
        }
    }
}

using UnityEngine;

public class HuntingState : StateBehaviour
{
    [SerializeField]
    float maxHuntingRange = 20f;
    float sqrMaxHuntingRange;

    [SerializeField]
    float attackRange = 2f;
    float sqrAttackRange;

    public override void StateEnter()
    {
        sqrMaxHuntingRange = maxHuntingRange * maxHuntingRange;
        sqrAttackRange = attackRange * attackRange;
    }

    public override void StateExit()
    {
        // Kann leer bleiben oder Debug-Ausgabe machen
    }

    public override void StateUpdate(float deltaTime)
    {
        myStateMachine.MyAgent.isStopped = false;
        myStateMachine.MyAgent.SetDestination(myStateMachine.PlayerTest.position);

        Vector3 toPlayer = myStateMachine.PlayerTest.position - myStateMachine.MyAgent.transform.position;
        float sqrDistanceToPlayer = toPlayer.sqrMagnitude;

        if (sqrDistanceToPlayer >= sqrMaxHuntingRange)
        {
            myStateMachine.SwitchState(myStateMachine.MyIdleState);
            return;
        }

        if (sqrDistanceToPlayer <= sqrAttackRange)
        {
            // Setze den AttackState, und übergib die AttackRange
            AttackState attackState = myStateMachine.MyAttackState;
            attackState.SetAttackRange(attackRange);
            myStateMachine.SwitchState(attackState);
        }
    }
}

//{
//    [SerializeField]
//    float maxHuntingRange;
//    float sqrMaxHuntingRange;

//    [SerializeField]
//    float attackRange;
//    float sqrAttackRange;
//    public override void StateEnter()
//    {
//        sqrMaxHuntingRange = maxHuntingRange * maxHuntingRange;
//        sqrAttackRange = attackRange * attackRange;
//    }

//    public override void StateExit()
//    {

//    }

//    public override void StateUpdate(float deltaTime)
//    {
//        myStateMachine.MyAgent.isStopped = false;
//        myStateMachine.MyAgent.SetDestination(myStateMachine.PlayerTransform.position);


//        Vector3 distanceToPlayer = myStateMachine.MyAgent.transform.position - myStateMachine.PlayerTransform.position;

//        if (distanceToPlayer.sqrMagnitude >= sqrMaxHuntingRange)
//        {
//            myStateMachine.SwitchState(myStateMachine.MyIdleState);
//        }

//        if (distanceToPlayer.sqrMagnitude >= sqrMaxHuntingRange)
//        {
//            myStateMachine.SwitchState(myStateMachine.MyIdleState);
//        }
//    }
//}

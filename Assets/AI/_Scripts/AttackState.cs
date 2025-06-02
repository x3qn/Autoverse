using UnityEngine;

public class AttackState : StateBehaviour
{
    float attackRange;
    float sqrAttackRange;

    public void SetAttackRange(float range)
    {
        attackRange = range;
        sqrAttackRange = range * range;
    }

    public override void StateEnter()
    {
        myStateMachine.MyAgent.isStopped = true;
        Debug.Log("Angriff gestartet!");
    }

    public override void StateExit()
    {
        Debug.Log("Angriff beendet!");
    }

    public override void StateUpdate(float deltaTime)
    {
        Vector3 toPlayer = myStateMachine.PlayerTest.position - myStateMachine.MyAgent.transform.position;
        float sqrDistance = toPlayer.sqrMagnitude;

        if (sqrDistance > sqrAttackRange)
        {
            myStateMachine.SwitchState(myStateMachine.MyHuntingState);
        }

        // Hier könntest du Angriffscooldowns, Animationen etc. einfügen
    }
}

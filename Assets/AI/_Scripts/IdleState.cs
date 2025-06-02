using UnityEngine;

public class IdleState : StateBehaviour
{
    [SerializeField]
    float range, waitingDuration, detectionRange;
    float waitingTimer;
    float sqrDetectionRange;
    public override void StateEnter()
    {
        waitingTimer = 0f;
        myStateMachine.MyAgent.isStopped = true;
        sqrDetectionRange = detectionRange * detectionRange;
    }

    public override void StateExit()
    {
        
    }

    public override void StateUpdate(float deltaTime)
    {
        waitingTimer += deltaTime;
        if (waitingTimer >= waitingDuration)
        {
            myStateMachine.MyAgent.isStopped = false;
            Vector3 offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            offset = offset.normalized * range;
            myStateMachine.MyAgent.SetDestination(myStateMachine.MyAgent.transform.position + offset);
            waitingTimer = 0f;
        }

        //if (myStateMachine.CurrentTarget == null)
        //{
        //    return; // kein Ziel vorhanden, also nicht weiter prüfen
        //}

        Vector3 distanceToTarget = myStateMachine.MyAgent.transform.position - myStateMachine.PlayerTest.position;//myStateMachine.CurrentTarget.position

        if (distanceToTarget.sqrMagnitude <= sqrDetectionRange)
        {
            myStateMachine.SwitchState(myStateMachine.MyHuntingState);
        }
    }
}

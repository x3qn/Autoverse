using UnityEngine;

public class IdleStateArcher : StateBehaviourArcher
{
    [SerializeField]
    float range = 5f, waitingDuration = 3f, detectionRange = 15f;
    float waitingTimer;
    float sqrDetectionRange;

    public override void StateEnter()
    {
        waitingTimer = 0f;
        myStateMachineArcher.MyAgent.isStopped = true;  // Stoppt den Agenten im Idle-Zustand
        sqrDetectionRange = detectionRange * detectionRange;  // Umrechnung in Quadratzentimeter (vermeidet Sqrt-Berechnung)
        Debug.Log("Archer ist im Idle-State.");
    }

    public override void StateExit()
    {
        // Optional: Aktionen, wenn der Archer den Idle-State verlässt
        Debug.Log("Archer verlässt den Idle-State.");
    }

    public override void StateUpdate(float deltaTime)
    {
        waitingTimer += deltaTime;

        // Archer wartet eine bestimmte Zeit, dann bewegt er sich leicht
        if (waitingTimer >= waitingDuration)
        {
            // Archer bewegt sich leicht, um die Umgebung zu beobachten
            myStateMachineArcher.MyAgent.isStopped = false;

            Vector3 offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            offset = offset.normalized * range;  // Bewegung in zufällige Richtung
            myStateMachineArcher.MyAgent.SetDestination(myStateMachineArcher.MyAgent.transform.position + offset);

            waitingTimer = 0f; // Timer zurücksetzen
        }

        // Prüfung auf ein Ziel in der Nähe (Erkennung des Ziels durch Detection Range)
        Vector3 distanceToTarget = myStateMachineArcher.MyAgent.transform.position - myStateMachineArcher.PlayerTest.position;

        if (distanceToTarget.sqrMagnitude <= sqrDetectionRange)
        {
            // Ziel erkannt, wechseln in den HuntingState
            myStateMachineArcher.SwitchState(myStateMachineArcher.MyAttackState);
        }
    }
}

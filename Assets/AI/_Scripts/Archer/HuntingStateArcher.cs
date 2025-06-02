using UnityEngine;

//public class HuntingStateArcher : StateBehaviourArcher
//{
//    [SerializeField]
//    float maxHuntingRange = 20f;
//    float sqrMaxHuntingRange;

//    [SerializeField]
//    float attackRange = 2f;
//    float sqrAttackRange;

//    [SerializeField]
//    float retreatRange = 1.5f; // Der Bereich, in dem sich der Archer zurückziehen soll
//    [SerializeField]
//    float retreatSpeed = 3f; // Rückzugs-Geschwindigkeit

//    public override void StateEnter()
//    {
//        sqrMaxHuntingRange = maxHuntingRange * maxHuntingRange;
//        sqrAttackRange = attackRange * attackRange;
//    }

//    public override void StateExit()
//    {
//        // Kann leer bleiben oder Debug-Ausgabe machen
//    }

//    public override void StateUpdate(float deltaTime)
//    {
//        myStateMachineArcher.MyAgent.isStopped = false;

//        // Berechnung der Distanz zum Ziel (Player)
//        Vector3 toPlayer = myStateMachineArcher.PlayerTest.position - myStateMachineArcher.MyAgent.transform.position;
//        float sqrDistanceToPlayer = toPlayer.sqrMagnitude;

//        // Wenn das Ziel außerhalb der Jagdreichweite ist, wechsle in den IdleState
//        if (sqrDistanceToPlayer >= sqrMaxHuntingRange)
//        {
//            myStateMachineArcher.SwitchState(myStateMachineArcher.MyIdleState);
//            return;
//        }

//        // Wenn der Feind zu nah ist, ziehe dich zurück
//        if (sqrDistanceToPlayer <= sqrAttackRange)
//        {
//            RetreatFromTarget(toPlayer);
//        }
//        else
//        {
//            // Ansonsten bewege dich normal auf das Ziel zu
//            myStateMachineArcher.MyAgent.SetDestination(myStateMachineArcher.PlayerTest.position);

//            // Wenn der Feind in Reichweite des Schusses ist, wechsle in den Angriffszustand
//            if (sqrDistanceToPlayer <= sqrAttackRange)
//            {
//                AttackStateArcher attackState = myStateMachineArcher.MyAttackState;
//                attackState.SetAttackRange(attackRange);
//                myStateMachineArcher.SwitchState(attackState);
//            }
//        }
//    }

//    // Funktion, um sich vom Ziel wegzubewegen
//    private void RetreatFromTarget(Vector3 toPlayer)
//    {
//        // Berechnung der Richtung vom Ziel weg
//        Vector3 retreatDirection = myStateMachineArcher.MyAgent.transform.position - myStateMachineArcher.PlayerTest.position;
//        retreatDirection = retreatDirection.normalized * retreatSpeed;

//        // Setze das Ziel der Bewegung
//        myStateMachineArcher.MyAgent.SetDestination(myStateMachineArcher.MyAgent.transform.position + retreatDirection);
//    }
//}

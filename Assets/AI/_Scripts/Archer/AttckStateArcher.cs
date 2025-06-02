using UnityEngine;

public class AttackStateArcher : StateBehaviourArcher
{
    [SerializeField] float maxHuntingRange = 20f;
    [SerializeField] float attackRange = 2f;
    [SerializeField] float retreatRange = 1.5f;
    [SerializeField] float retreatSpeed = 3f;

    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowSpawnPoint;
    [SerializeField] float shootCooldown = 2f;
    [SerializeField] float arrowForce = 30f;

    private float sqrMaxHuntingRange;
    private float sqrAttackRange;
    private float shootTimer;

    public override void StateEnter()
    {
        sqrMaxHuntingRange = maxHuntingRange * maxHuntingRange;
        sqrAttackRange = attackRange * attackRange;
        shootTimer = 0f;
        myStateMachineArcher.MyAgent.isStopped = false;
        Debug.Log("Archer in Jagd- und Angriffszustand.");
    }

    public override void StateExit()
    {
        Debug.Log("Archer verl�sst den Jagd- und Angriffszustand.");
    }

    public override void StateUpdate(float deltaTime)
    {
        shootTimer += deltaTime;

        if (myStateMachineArcher.CurrentTarget == null)
        {
            myStateMachineArcher.SwitchState(myStateMachineArcher.MyIdleState);
            return;
        }

        // Berechnung der Distanz zum Ziel (Player)
        Vector3 toPlayer = myStateMachineArcher.CurrentTarget.position - myStateMachineArcher.MyAgent.transform.position;
        float sqrDistanceToPlayer = toPlayer.sqrMagnitude;

        // Wenn der Feind zu nah ist, ziehe dich zur�ck
        if (sqrDistanceToPlayer <= sqrAttackRange)
        {
            RetreatFromTarget(toPlayer);
        }
        else
        {
            // Ansonsten bewege dich auf das Ziel zu
            myStateMachineArcher.MyAgent.SetDestination(myStateMachineArcher.CurrentTarget.position);

            // Wenn der Feind in Reichweite des Schusses ist, schie�e einen Pfeil
            if (sqrDistanceToPlayer <= sqrAttackRange && shootTimer >= shootCooldown)
            {
                ShootArrow();
                shootTimer = 0f; // Cooldown zur�cksetzen
            }
        }

        // Wenn der Feind au�erhalb der Jagdreichweite ist, wechsle in den IdleState
        if (sqrDistanceToPlayer >= sqrMaxHuntingRange)
        {
            myStateMachineArcher.SwitchState(myStateMachineArcher.MyIdleState);
        }
    }

    private void RetreatFromTarget(Vector3 toPlayer)
    {
        // Berechnung der R�ckzugsrichtung
        Vector3 retreatDirection = myStateMachineArcher.MyAgent.transform.position - myStateMachineArcher.CurrentTarget.position;
        retreatDirection = retreatDirection.normalized * retreatSpeed;

        // Setze das Ziel der Bewegung
        myStateMachineArcher.MyAgent.SetDestination(myStateMachineArcher.MyAgent.transform.position + retreatDirection);
    }

    private void ShootArrow()
    {
        if (arrowPrefab == null || arrowSpawnPoint == null)
        {
            Debug.LogWarning("Arrow Prefab oder SpawnPoint fehlt!");
            return;
        }

        GameObject arrow = GameObject.Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        if (rb != null && myStateMachineArcher.CurrentTarget != null)
        {
            Vector3 direction = (myStateMachineArcher.CurrentTarget.position - arrowSpawnPoint.position).normalized;
            rb.linearVelocity = direction * arrowForce;  // Verwende velocity f�r eine realistischere Bewegung
        }

        Debug.Log("Pfeil abgeschossen!");
    }
}


using UnityEngine;

public abstract class StateBehaviourArcher : MonoBehaviour
{
    protected FiniteStateMachineArcher myStateMachineArcher;

    public void Start()
    {
        myStateMachineArcher = GetComponent<FiniteStateMachineArcher>();
    }
    public abstract void StateEnter();
    public abstract void StateExit();
    public abstract void StateUpdate(float deltaTime);

}
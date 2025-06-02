using UnityEngine;

public abstract class StateBehaviour : MonoBehaviour
{
    protected FiniteStateMachine myStateMachine;

    public void Start()
    {
        myStateMachine = GetComponent<FiniteStateMachine>();
    }
    public abstract void StateEnter();
    public abstract void StateExit();
    public abstract void StateUpdate(float deltaTime);

}

using UnityEngine;

public class DoorClosedState : IState
{
    public void EnterState(IStateMachine stateMachine)
    {
        DoorStateMachine dm = stateMachine as DoorStateMachine;
        dm.gameObject.layer = LayerMask.NameToLayer("Obstacle");
    }

    public void ExitState(IStateMachine stateMachine)
    {

    }

    public void OnCollisonEnter(IStateMachine stateMachine, Collision collision)
    {

    }

    public void Trigger(IStateMachine stateMachine, Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public void Update(IStateMachine stateMachine)
    {

    }
}
using UnityEngine;

public class StateSwitchOff : IState
{
    public void EnterState(IStateMachine stateMachine)
    {
        (stateMachine as SwitchStateMachine).button.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void ExitState(IStateMachine stateMachine)
    {

    }

    public void OnCollisonEnter(IStateMachine stateMachine, Collision collision)
    {
        stateMachine.SwitchState((stateMachine as SwitchStateMachine).stateSwitchOn);
    }

    public void Trigger(IStateMachine stateMachine, Collider collider)
    {
        stateMachine.SwitchState((stateMachine as SwitchStateMachine).stateSwitchOn);
    }

    public void Update(IStateMachine stateMachine)
    {

    }
}

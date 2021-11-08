using UnityEngine;

public class StateSwitchOn : IState
{
    public void EnterState(IStateMachine stateMachine)
    {
        SwitchStateMachine sm = stateMachine as SwitchStateMachine;
        (stateMachine as SwitchStateMachine).button.GetComponent<MeshRenderer>().material.color = Color.green;
        if (sm.timer > 0)
        {
            stateMachine.SwitchState(sm.stateSwitchTimer);
        }
    }

    public void ExitState(IStateMachine stateMachine)
    {

    }

    public void OnCollisonEnter(IStateMachine stateMachine, Collision collision)
    {
        SwitchStateMachine sm = stateMachine as SwitchStateMachine;
        if (sm.timer == 0)
        {
            stateMachine.SwitchState(sm.stateSwitchOff);
        }
    }

    public void Trigger(IStateMachine stateMachine, Collider collider)
    {
        stateMachine.SwitchState((stateMachine as SwitchStateMachine).stateSwitchOff);
    }

    public void Update(IStateMachine stateMachine)
    {

    }
}

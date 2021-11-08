using UnityEngine;

public class StateSwitchTimer : IState
{
    float elapsedTime = 0;
    public void EnterState(IStateMachine stateMachine)
    {
        SwitchStateMachine sm = stateMachine as SwitchStateMachine;
    }

    public void ExitState(IStateMachine stateMachine)
    {
        elapsedTime = 0;
    }

    public void OnCollisonEnter(IStateMachine stateMachine, Collision collision)
    {

    }

    public void Trigger(IStateMachine stateMachine, Collider collider)
    {

    }

    public void Update(IStateMachine stateMachine)
    {
        SwitchStateMachine sm = stateMachine as SwitchStateMachine;
        if (elapsedTime > sm.timer)
        {
            sm.SwitchState(sm.stateSwitchOff);
        }
        elapsedTime += Time.deltaTime;
    }

}

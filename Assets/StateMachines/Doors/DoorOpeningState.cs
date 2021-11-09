using UnityEngine;

public class DoorOpeningState : IState
{
    private Vector3 startVect;
    private Vector3 offset = new Vector3(0, -1.05f, 0);
    private float elapsedTime = 0;
    private float duration = 0.1f;

    public void EnterState(IStateMachine stateMachine)
    {
        DoorStateMachine dm = stateMachine as DoorStateMachine;
        startVect = dm.door.transform.localPosition;
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
        throw new System.NotImplementedException();
    }

    public void Update(IStateMachine stateMachine)
    {
        DoorStateMachine dm = stateMachine as DoorStateMachine;
        dm.door.transform.localPosition = Vector3.Lerp(startVect, offset, elapsedTime / duration);
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= duration)
        {
            dm.door.transform.localPosition = offset;
            dm.SwitchState(dm.doorOpenState);
        }
    }
}
using UnityEngine;

public class DoorStateMachine : MonoBehaviour, IStateMachine
{

    private IState currentState;
    public DoorOpenState doorOpenState = new DoorOpenState();
    public DoorOpeningState doorOpeningState = new DoorOpeningState();
    public DoorClosedState doorClosedState = new DoorClosedState();
    public DoorClosingState doorClosingState = new DoorClosingState();

    public void Start()
    {
        currentState = doorClosedState;
        currentState.EnterState(this);
    }


    public void Update()
    {
        currentState.Update(this);
    }

    public void SwitchState(IState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        newState.EnterState(this);
    }
}
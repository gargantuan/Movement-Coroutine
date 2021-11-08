using UnityEngine;

public class SwitchStateMachine : MonoBehaviour, IStateMachine
{
    private IState currentState;
    [SerializeField] public GameObject button;
    [SerializeField] public float timer = 0;

    public StateSwitchOff stateSwitchOff = new StateSwitchOff();
    public StateSwitchOn stateSwitchOn = new StateSwitchOn();
    public StateSwitchTimer stateSwitchTimer = new StateSwitchTimer();

    public void Start()
    {
        currentState = stateSwitchOff;
        currentState.EnterState(this);
    }


    public void Update()
    {
        if (currentState != null) currentState.Update(this);
    }

    public void SwitchState(IState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        newState.EnterState(this);
    }

    public void OnTriggerEnter(Collider collider)
    {
        currentState.Trigger(this, collider);
    }

}
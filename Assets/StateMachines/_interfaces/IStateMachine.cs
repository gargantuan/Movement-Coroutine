public interface IStateMachine
{
    void Start();
    void Update();
    void SwitchState(IState newState);
}

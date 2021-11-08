
using UnityEngine;

public interface IState
{
    void EnterState(IStateMachine stateMachine);
    void ExitState(IStateMachine stateMachine);
    void OnCollisonEnter(IStateMachine stateMachine, Collision collision);
    void Update(IStateMachine stateMachine);
    void Trigger(IStateMachine stateMachine, Collider collider);
}
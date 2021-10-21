using UnityEngine;

public class HomePlate : MonoBehaviour
{
    [SerializeField] public GameEvent reachedEvent;


    void OnTriggerEnter(Collider other)
    {
        reachedEvent.Invoke();
    }
}

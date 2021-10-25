using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameEvent enemyCollisionEvent;
    [SerializeField] Transform homeplateTransform;
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnCollisionEnter");
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with enemy");
            enemyCollisionEvent.Invoke();
            if (homeplateTransform != null)
            {
                transform.position = homeplateTransform.position;
            }
        }
    }
}

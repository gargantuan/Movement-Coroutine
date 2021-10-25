using UnityEngine;

public class Nugget : MonoBehaviour
{

    [SerializeField] GamePlayState gamePlayState;
    private Transform carrierTransform;
    private Vector3 carrierOffset = new Vector3(0, 2.5f, 0);

    // Update is called once per frame
    void LateUpdate()
    {
        if (carrierTransform)
        {
            transform.position = carrierTransform.position + carrierOffset;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !gamePlayState.isCarryingNugget)
        {
            carrierTransform = other.transform;
            gamePlayState.isCarryingNugget = true;
        }
    }

    public void DoCollected()
    {
        if (this.carrierTransform)
        {
            gamePlayState.SaveNugget();
            Destroy(this.gameObject);
        }
    }

    public void Drop()
    {
        this.carrierTransform = null;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        gamePlayState.isCarryingNugget = false;
    }

}

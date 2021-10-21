using UnityEngine;

public class Nugget : MonoBehaviour
{

    [SerializeField] GamePlayState gamePlayState;
    private Transform carrierTransform;
    [SerializeField] private Vector3 carrierOffset = new Vector3(0, 0, 2.5f);

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
        if (!gamePlayState.isCarryingNugget)
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


}

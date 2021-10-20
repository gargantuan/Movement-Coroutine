using UnityEngine;

public class Nugget : MonoBehaviour
{

    [SerializeField] GamePlayState gamePlayState;
    private Transform carrierTransform;
    [SerializeField] private Vector3 carrierOffset = new Vector3(0, 0, 2.5f);
    // Start is called before the first frame update
    void Start()
    {

    }

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
        if (!gamePlayState.isCarrying)
        {
            carrierTransform = other.transform;
            gamePlayState.isCarrying = true;
        }
    }
}

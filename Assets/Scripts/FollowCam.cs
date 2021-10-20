using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - targetTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = targetTransform.position + offset;
    }
}

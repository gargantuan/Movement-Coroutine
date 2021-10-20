using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField] float degressPerSecond = 90f;
    void Update()
    {
        transform.Rotate(new Vector3(degressPerSecond * 1.25f, degressPerSecond * .5f, degressPerSecond) * Time.deltaTime, Space.World);
    }
}

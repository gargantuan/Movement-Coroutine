using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField] private float stepTime = 5f;
    private Coroutine movementCoroutine;
    private Vector3 direction = Vector3.zero;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        // he
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && direction != Vector3.zero)
        {
            movementCoroutine = StartCoroutine(SmoothLerp(stepTime));
        }
    }

    private IEnumerator SmoothLerp(float time)
    {
        isMoving = true;
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + direction;
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            yield return null;
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
        }
        transform.position = endPos;
        isMoving = false;
    }

    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;
    }
}

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
            if (CanMoveToNextTile())
            {
                movementCoroutine = StartCoroutine(DoMovement(stepTime));
            }
            else
            {
                direction = Vector3.zero;
            }
        }
    }

    private IEnumerator DoMovement(float time)
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

    private bool CanMoveToNextTile()
    {
        float rayDepth = 3;
        RaycastHit hit;
        Vector3 rayPoint = transform.position + direction + Vector3.up * 2;
        if (Physics.Raycast(rayPoint, Vector3.down, out hit, rayDepth))
        {
            return hit.transform.gameObject.layer == LayerMask.NameToLayer("Obstacle") ? false : true;
        }
        return false;
    }

    void OnDrawGizmos()
    {
        Vector3 rayPoint = transform.position + direction + Vector3.up * 2;
        Gizmos.DrawSphere(rayPoint, 0.25f);
        Gizmos.DrawLine(rayPoint, rayPoint + Vector3.down * 3);
    }

    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;
    }
}

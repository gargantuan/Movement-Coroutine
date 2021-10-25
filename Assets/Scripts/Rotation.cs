using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float step = 0.125f;

    private Coroutine rotationCoroutine;
    private bool isRotating = false;
    private Quaternion targetRotation = Quaternion.Euler(Vector3.zero);

    // Update is called once per frame
    void Update()
    {
        if (!isRotating && targetRotation != transform.rotation)
        {
            rotationCoroutine = StartCoroutine(DoRotation(step));
        }
    }

    private IEnumerator DoRotation(float timeStep)
    {
        Debug.Log(string.Format("DoRotation called {0}", targetRotation));
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = targetRotation;
        float timeElapsed = 0;
        while (timeElapsed < timeStep)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, (timeElapsed / timeStep));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRotation;
        isRotating = false;
    }

    public void SetRotation(Vector3 rotationVector)
    {
        Debug.Log(string.Format("SetRotation called {0}", rotationVector));
        targetRotation = Quaternion.Euler(rotationVector);
    }
}

using UnityEngine;
using System.Collections;

public class Movement_Wander : MonoBehaviour
{
    private Movement movement;
    private Rotation rotation;
    private Coroutine wanderCoroutine;
    private Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
    private Vector3[] rotations = { new Vector3(0, 0, 0), new Vector3(0, 180, 0), new Vector3(0, -90, 0), new Vector3(0, 90, 0) };

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<Movement>();
        rotation = GetComponent<Rotation>();
    }


    // Update is called once per frame
    void Start()
    {
        wanderCoroutine = StartCoroutine(DoWander());
    }

    private IEnumerator DoWander()
    {
        while (true)
        {
            var randomIndex = Random.Range(0, directions.Length);
            rotation.SetRotation(rotations[randomIndex]);
            movement.SetDirection(directions[randomIndex]);
            yield return new WaitForSeconds(3);
        }
    }
}

using UnityEngine;

public class GameplayLogic : MonoBehaviour
{
    [SerializeField] GamePlayState gamePlayState;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayState.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        gamePlayState.gameTime += Time.deltaTime;
    }
}

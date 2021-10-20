using UnityEngine;

[CreateAssetMenu(fileName = "GamePlayState", menuName = "States/GamePlayState")]
public class GamePlayState : ScriptableObject
{
    public float gameTime;
    public bool isCarrying;

    public void Reset()
    {
        gameTime = 0;
        isCarrying = false;
    }
}

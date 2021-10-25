using UnityEngine;

[CreateAssetMenu(fileName = "GamePlayState", menuName = "States/GamePlayState")]
public class GamePlayState : ScriptableObject
{
    public float gameTime;
    public int lives = 3;

    public float totalNuggets = 0;
    public float nuggetTally = 0;
    public bool isCarryingNugget = false;
    public void Reset()
    {
        gameTime = 0;
        nuggetTally = 0;
        isCarryingNugget = false;
        lives = 3;
    }

    public void SaveNugget()
    {
        nuggetTally++;
        isCarryingNugget = false;
    }
}

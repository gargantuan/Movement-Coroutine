using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayLogic : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GamePlayState gamePlayState;

    private Coroutine scoreUpdateCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        scoreUpdateCoroutine = StartCoroutine(DoScoreUpdate(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        gamePlayState.gameTime += Time.deltaTime;
    }

    private void Reset()
    {
        gamePlayState.Reset();
        gamePlayState.totalNuggets = GameObject.FindGameObjectsWithTag("Nugget").Length;
        scoreText.text = string.Format("{0}/{1}", gamePlayState.nuggetTally, gamePlayState.totalNuggets);
    }

    private IEnumerator DoScoreUpdate(float interval)
    {
        while (true)
        {
            scoreText.text = string.Format("{0}/{1}", gamePlayState.nuggetTally, gamePlayState.totalNuggets);
            yield return new WaitForSeconds(interval);
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayLogic : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GamePlayState gamePlayState;

    private Coroutine scoreUpdateCoroutine;

    [SerializeField]
    private GameObject gameCompleteCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        Time.timeScale = 1;
        gameCompleteCanvas.SetActive(false);
        scoreUpdateCoroutine = StartCoroutine(DoScoreUpdate(0.125f));
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
            if (gamePlayState.nuggetTally == gamePlayState.totalNuggets)
            {
                Time.timeScale = 0;
                gameCompleteCanvas.SetActive(true);
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gm;

    public void RestartGame()
    {

        gm = FindAnyObjectByType<GameManager>();
        if (gm != null)
        {
            gm.isGameOver = false;
            gm.score = 0;
            gm.maxEnemies = 3;
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

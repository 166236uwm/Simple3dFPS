using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int maxEnemies = 3;
    private int currentEnemyCount = 0;
    public TextMeshProUGUI scoreText;

    public GameObject[] enemyPrefabs; // Prefaby przeciwników do generowania
    public Transform[] spawnPoints; // Punkty generowania przeciwników

    public GameObject gameOverUI;
    public TextMeshProUGUI finalScoreText;

    public GameObject player;
    private PlayerHealth ph;

    private bool isGameOver = false;
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Wynik: " + score;
        ph = player.GetComponent<PlayerHealth>();
        ph.RestoreHealth();
    }

    public void DecrementEnemyCount()
    {
        Debug.Log("Current Enemy Count: " + currentEnemyCount);
        currentEnemyCount--;
        if (score % 10 == 0)
        {
            maxEnemies++;
        }
    }

    void Update()
    {
        if (currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(
            enemyPrefabs[randomEnemyIndex],
            spawnPoints[randomSpawnPointIndex].position,
            Quaternion.identity
        );

        currentEnemyCount++;
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        finalScoreText.text = "Wynik: " + score;
        player.SetActive(false);
    }
}

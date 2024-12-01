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

    public bool isGameOver = false;

    void Start()
    {
        LockCursor();
    }
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Wynik: " + score;
        ph = player.GetComponent<PlayerHealth>();
        ph.RestoreHealth();
    }

    public void DecrementEnemyCount()
    {
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
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
        isGameOver = true;
        gameOverUI.SetActive(true);
        finalScoreText.text = "Wynik: " + score;
        Time.timeScale = 0f;
        UnlockCursor() ;
    }
    public void LockCursor()
    {
        if (!isGameOver)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;  
        Cursor.visible = true;                   
    }
}

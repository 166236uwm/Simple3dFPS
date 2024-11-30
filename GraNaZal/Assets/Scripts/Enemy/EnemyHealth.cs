using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private EnemyReferences enemyReferences;
    private GameManager gm;

    private int health;
    private float damageTaken;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        gm = FindAnyObjectByType<GameManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = enemyReferences.maxHealth;
        damageTaken = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, enemyReferences.maxHealth);

    }
    public void TakeDamage()
    {
        if (damageTaken + enemyReferences.gracePeriod <= Time.time) 
        { 
            health -= 1;
            damageTaken = Time.time;
            if (health <= 0)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        if (gm != null)
        {
            gm.AddScore(1);
            gm.DecrementEnemyCount();
        }

        Destroy(gameObject);
    }
}

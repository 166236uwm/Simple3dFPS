using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private int health;
    private int maxHealth = 2;
    public float gracePeriod = 0.2f;
    private float damageTaken;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        damageTaken = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health <= 0)
        {
            Die();
        }
        if(damageTaken > 30f)
        {
            health = maxHealth;
            Debug.Log("Bot is Healed");
        }
    }
    public void TakeDamage()
    {
        if (damageTaken + gracePeriod <= Time.time) 
        { 
            health -= 1;
            damageTaken = Time.time;
        }
    }
    public void Die()
    {
        Debug.Log("Bot is Dead");
    }
}

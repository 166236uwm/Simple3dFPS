using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private int health;
    private int maxHealth = 3;
    public Image healthBarFull;
    public Image healthBar2_3;
    public Image healthBar1_3;
    public Image healthBarEmpty;
    public float gracePeriod = 1.2f;
    private float damageTaken;
    private GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GetComponent<GameManager>();
        health = maxHealth;
        damageTaken = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUi();
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            RestoreHealth();
        }
    }
    public void UpdateHealthUi()
    {
        switch (health)
        {
            case 0:
                healthBarEmpty.gameObject.SetActive(true);
                healthBar1_3.gameObject.SetActive(false);
                healthBar2_3.gameObject.SetActive(false);
                healthBarFull.gameObject.SetActive(false);
                Die();
                break;
            case 1:
                healthBarEmpty.gameObject.SetActive(false);
                healthBar1_3.gameObject.SetActive(true);
                healthBar2_3.gameObject.SetActive(false);
                healthBarFull.gameObject.SetActive(false);
                break;
            case 2:
                healthBarEmpty.gameObject.SetActive(false);
                healthBar1_3.gameObject.SetActive(false);
                healthBar2_3.gameObject.SetActive(true);
                healthBarFull.gameObject.SetActive(false);
                break;
            case 3:
                healthBarEmpty.gameObject.SetActive(false);
                healthBar1_3.gameObject.SetActive(false);
                healthBar2_3.gameObject.SetActive(false);
                healthBarFull.gameObject.SetActive(true);
                break;
            default: break;
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
    public void RestoreHealth()
    {
        health += 1;
    }
    public void Die()
    {
        gm.GameOver();
    }

}

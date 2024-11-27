using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    private int maxHealth = 3;
    public Image healthBarFull;
    public Image healthBar2_3;
    public Image healthBar1_3;
    public Image healthBarEmpty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUi();
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamege();
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
    public void TakeDamege()
    {
        health -= 1;
    }
    public void RestoreHealth()
    {
        health += 1;
    }
    public void Die()
    {
        Debug.Log("Dead");
    }
}

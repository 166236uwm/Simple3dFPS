using UnityEngine;

public class CollideToDealDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sprawdzenie tagu
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamege(); // Zmniejsz zdrowie gracza
            }
        }
    }

}

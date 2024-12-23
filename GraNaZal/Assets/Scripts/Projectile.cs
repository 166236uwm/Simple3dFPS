using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask hitLayers;
    private Vector3 lastPosition;
    private bool isInitialized = false;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (!isInitialized) return;

        Vector3 currentPosition = transform.position;
        Vector3 direction = currentPosition - lastPosition;
        float distance = direction.magnitude;

        if (distance > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(lastPosition, direction, out hit, distance, hitLayers))
            {
                HandleHit(hit.collider);
                return;
            }
        }

        lastPosition = currentPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isInitialized)
        {
            return;
        }
        HandleHit(collision.collider);
    }

    public void InitializeProjectile()
    {
        isInitialized = true;
    }

    private void HandleHit(Collider collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage();
            Destroy(gameObject, 3f);
            return;
        }

        Destroy(gameObject, 3f);
    }
}

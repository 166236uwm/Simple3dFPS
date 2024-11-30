using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShoot : MonoBehaviour
{
    [Header("General")]
    public Transform shootPoint; // where stuff is shot from
    public LayerMask layerMask;

    public GameObject vegetablePrefab;

    private float lastShootTime;

    private EnemyReferences enemyReferences;
    private void Awake()
    {
            enemyReferences = GetComponent<EnemyReferences>();
    }
    public void Shoot()
    {
        if (Time.time >= lastShootTime + enemyReferences.shootDelay)
        {

            int x = 1;
            if(gameObject.tag == "EnemyHeavy") { x = 10; Debug.Log("here"); }
            for (int i = 0; i < x; i++)
            {
                GameObject vegetable = Instantiate(vegetablePrefab, shootPoint.position, shootPoint.rotation);
                Rigidbody rb = vegetable.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.useGravity = true;
                    Vector3 direction = GetDirection(enemyReferences.spread);
                    rb.AddForce(direction * enemyReferences.shootForce, ForceMode.VelocityChange);
                }
                Projectile projectile = vegetable.GetComponent<Projectile>();
                if (projectile != null)
                {
                    projectile.InitializeProjectile();
                }
            }
            lastShootTime = Time.time;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private Vector3 GetDirection(Vector3 spread)
    {
        Vector3 direction = transform.forward;
        direction = (enemyReferences.target.position - shootPoint.position).normalized;
        direction += new Vector3(
            Random.Range(-spread.x, spread.x),
            Random.Range(-spread.y, spread.y),
            Random.Range(-spread.z, spread.z));
        return direction;
    }
}

using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("General")]
    public Transform shootPoint; // where stuff is shot from
    public LayerMask layerMask;

    private EnemyReferences enemyReferences;
    private void Awake()
    {
            enemyReferences = GetComponent<EnemyReferences>();
    }
    public void Shoot()
    {
        Vector3 spread = new Vector3(0.06f, 0.06f, 0.06f);
        Vector3 direction = GetDirection(spread);
        //TODO: spawn damage dealer object with certain velocity in *direction*
        Debug.Log("Shot!");
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
        direction += new Vector3(
                Random.Range(-spread.x, spread.x),
                Random.Range(-spread.y, spread.y),
                Random.Range(-spread.z, spread.z)
            );
        direction.Normalize();
        return direction;
    }
}

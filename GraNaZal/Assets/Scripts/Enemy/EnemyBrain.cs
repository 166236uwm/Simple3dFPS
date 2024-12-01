using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private EnemyReferences enemyReferences;
    private float shootingDistance;
    private float pathUpdateDeadLine;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }
    void Start()
    {
        shootingDistance = enemyReferences.navMeshAgent.stoppingDistance;
    }

    void Update()
    {
        if (enemyReferences.target != null)
        {
            bool inRange = Vector3.Distance(transform.position, enemyReferences.target.position) <= shootingDistance;
            if (inRange && HasLineOfSight())
            {
                LookAtTarget();
                GetComponent<EnemyShoot>().Shoot();
            }
            else
            {
                UpdatePath();
            }
        }
    }
    private void LookAtTarget()
    {
        Vector3 lookPos = enemyReferences.target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }
    private void UpdatePath()
    {
        if(Time.time >= pathUpdateDeadLine)
        {
            pathUpdateDeadLine = Time.time + enemyReferences.pathUpdateDelay;
            enemyReferences.navMeshAgent.SetDestination(enemyReferences.target.position);
        }
    }
    private bool HasLineOfSight()
    {
        Vector3 directionToTarget = (enemyReferences.target.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, enemyReferences.target.position);

        if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hit, distanceToTarget, enemyReferences.layerMask))
        {
            if (hit.transform == enemyReferences.target)
            {
                return true;
            }
        }

        return false;
    }
}

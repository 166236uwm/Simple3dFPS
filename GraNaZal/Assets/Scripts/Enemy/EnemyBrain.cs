using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform target;
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
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;
            if (inRange)
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }
        }
    }
    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }
    private void UpdatePath()
    {
        if(Time.time >= pathUpdateDeadLine)
        {
            Debug.Log("updating path..");
            pathUpdateDeadLine = Time.time + enemyReferences.pathUpdateDelay;
            enemyReferences.navMeshAgent.SetDestination(target.position);
        }
    }
}

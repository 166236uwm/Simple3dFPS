using UnityEngine;
using UnityEngine.AI;

public class EnemyReferences : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public int maxHealth;
    public float gracePeriod;
    public float shootForce;
    public float shootDelay;
    public Transform target;
    public Vector3 spread;

    [Header("Stats")]
    public float pathUpdateDelay = 0.2f;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float s;
        switch (gameObject.tag)
        {
            case "EnemySniper":
                maxHealth = 1;
                gracePeriod = 0.2f;
                shootDelay = 4f;
                shootForce = 80f;
                s = 0.01f;
                break;
            case "EnemyHeavy":
                maxHealth = 5;
                gracePeriod = 0.2f;
                shootDelay = 2f;
                shootForce = 25f;
                s = 0.2f;
                break;
            case "EnemyAssault":
                maxHealth = 2;
                gracePeriod = 0.3f;
                shootDelay = 0.5f;
                shootForce = 30f;
                s = 0.06f;
                break;
            default:
                maxHealth = 20;
                gracePeriod = 6f;
                shootDelay = 0.01f;
                shootForce = 300f;
                s = 0;
                break;
        }
        spread = new Vector3(s, s, s);
    }

}

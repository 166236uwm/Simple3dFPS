using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("General")]
    public Transform shootPoint; // where stuff is shot from
    public Transform cameraTransform;
    public LayerMask layerMask;

    public GameObject vegetablePrefab;
    public float shootForce = 30f;
    public float shootDelay = 0.5f;

    private float lastShootTime;
    public void Shoot()
    {
        if (Time.time >= lastShootTime + shootDelay)
        {
            GameObject vegetable = Instantiate(vegetablePrefab, shootPoint.position, shootPoint.rotation);

            Rigidbody rb = vegetable.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.useGravity = true;
                float s = 0.02f;
                Vector3 spread = new Vector3(s, s, s);
                Vector3 direction = GetDirection(spread);
                Debug.DrawRay(shootPoint.position, direction * 10f, Color.red, 2f);
                rb.AddForce(direction * shootForce, ForceMode.VelocityChange);
            }
            Projectile projectile = vegetable.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.InitializeProjectile();
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
        Vector3 direction = cameraTransform.forward;
        direction += new Vector3(
                Random.Range(-spread.x, spread.x),
                Random.Range(-spread.y, spread.y),
                Random.Range(-spread.z, spread.z)
            );
        direction.Normalize();
        return direction;
    }
}
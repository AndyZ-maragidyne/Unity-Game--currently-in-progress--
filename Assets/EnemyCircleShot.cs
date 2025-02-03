using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleShot : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed = 8f;
    public float shootInterval = 0.05f;
    public int numProjectiles = 16;
    private int i = 0;
    private float angleStep;
    private float angle;
    private float radian;

    void Start()
    {
        angleStep = 360f / numProjectiles;
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            i = (i + 1) % numProjectiles;


            angle = i * angleStep; // Angle for each projectile
            radian = angle * Mathf.Deg2Rad; // Convert to radians

            // Calculate direction using unit circle
            Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

            // Call your ShootProjectile method
            ShootProjectile(direction);
            
        }
    }

    void ShootProjectile(Vector2 direction)
    {
        // Instantiate the projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        projectile.tag = "Enemy Projectile";

        // Give the projectile a downward velocity
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction.normalized * projectileSpeed;
    }
}

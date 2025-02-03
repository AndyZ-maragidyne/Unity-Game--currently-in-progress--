using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBurstShot : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed = 8f;
    public float shootMin = 0f;
    public float shootMax = 4f;
    public float shootInterval;

    void Start()
    {
        shootInterval = UnityEngine.Random.Range(shootMin, shootMax);

        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            shootInterval = UnityEngine.Random.Range(shootMin, shootMax);
            // Shoot a projectile
            for (int i = 0; i < 5; i++) // Fire 5 continuous shots
            {
                ShootProjectile(); // Fire a single projectile
                yield return new WaitForSeconds(0.2f); // Adjust this value for the delay between shots
            }

        }
    }

    void ShootProjectile()
    {
        // Instantiate the projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        projectile.tag = "Enemy Projectile";

        // Give the projectile a downward velocity
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = Vector2.down * projectileSpeed;
    }
}

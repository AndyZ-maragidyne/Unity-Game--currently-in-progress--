using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public Rigidbody2D my_Rigidbody; // Rigidbody2D of the enemy
    public GameObject coinPrefab; // Prefab for the projectile
    public GameObject healthPrefab;
    public Transform projectileSpawnPoint; // Spawn point for projectiles
    public int lives = 1;

    public float LootSpeed = 4f;

    private Vector2 startPosition; // Starting position of the enemy

    // Start is called before the first frame update
    void Start()
    {
        //startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       //float newPosition = Mathf.PingPong(Time.time * moveSpeed, moveRange) - moveRange / 2f;
       //transform.position = new Vector2(startPosition.x + newPosition, transform.position.y);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider is tagged as "Projectile"
        if (collision.CompareTag("Friendly Projectile"))
        {
            lives--;
            Destroy(collision.gameObject); // Destroy the projectile
            if (lives <= 0)
            {
                // Destroy the enemy and the projectile
                UnityEngine.Debug.Log("The enemy died :(");
                Destroy(gameObject); // Destroy this enemy

                // Instantiate the projectile at the spawn point
                GameObject item;
                int random = UnityEngine.Random.Range(0, 100);
                if (random <= 10)
                {
                    if (random == 0)
                    {
                        item = Instantiate(healthPrefab, projectileSpawnPoint.position, Quaternion.identity);
                    }
                    else
                    {
                        item = Instantiate(coinPrefab, projectileSpawnPoint.position, Quaternion.identity);
                    }
                    item.tag = "Item";

                    // Give the projectile a downward velocity
                    Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
                    itemRb.velocity = Vector2.down * LootSpeed;
                }
            }
        }
    }
}

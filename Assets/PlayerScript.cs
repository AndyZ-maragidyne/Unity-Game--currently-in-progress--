using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameOverManager GameOverScreen;
    public Rigidbody2D my_Rigidbody;
    public GameObject projectilePrefab; // Assign your projectile prefab here
    public Transform projectileSpawnPoint; // Assign the spawn point for the projectile
    public float moveSpeed = 15f;
    public float projectileSpeed = 10f;
    public int lives = 3;
    public int coins = 0;
    private bool isRolling = false;
    public PlayerDataSO playerLives;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ShootProjectile()
    {
        // Instantiate the projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        projectile.tag = "Friendly Projectile";
        // Get the Rigidbody2D component of the projectile and apply upward velocity
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = Vector2.up * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRolling)
        {
            float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrow
            float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down arrow

            // Set the velocity of the Rigidbody2D
            my_Rigidbody.velocity = new Vector2(moveX, moveY) * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootProjectile();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dodgeRoll();
        }
    }

    void Die()
    {
        // Logic for player death
        System.Console.WriteLine("Player has died!");
        // Disable the player or restart the level
        gameObject.SetActive(false);
        // You could also load a "Game Over" scene here
        GameOverScreen.Setup();
    }

    public void TakeDamage()
    {
        playerLives.Lives--;
        System.Console.WriteLine("Player got hurt :( " + playerLives.Lives + " lives");

        if (playerLives.Lives <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider is tagged as "Projectile"
        if (collision.CompareTag("Enemy Projectile"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        } else if (collision.CompareTag("Item"))
        {
            UnityEngine.Debug.Log("Touched a coin");
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                item.OnPickup(this); // Pass the player instance for context
            }
            Destroy(collision.gameObject);
        }
    }

    public void increaseCoins(int amount)
    {
        coins += amount;
    }

    public void increaseLives(int amount)
    {
        playerLives.Lives += amount;
    }

    public void doSwipe()
    {

    }

    public void dodgeRoll()
    {

        //must only activate if another movement key is pressed
        //give a boost of movement in that direction
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Only activate dodgeRoll if a movement key is pressed
        if (moveX != 0 || moveY != 0)
        {
            isRolling = true;
            UnityEngine.Debug.Log("DodgeRoll activated!");

            // Calculate the dodge direction (normalized to ensure consistent speed)
            Vector2 dodgeDirection = new Vector2(moveX, moveY).normalized;

            // Temporarily increase the speed in the dodge direction
            float dodgeSpeed = 30f; // Speed during the dodge roll
            float dodgeDuration = 0.2f; // Duration of the dodge roll in seconds

            // Set velocity directly to apply the boost in the current direction
            my_Rigidbody.velocity = dodgeDirection * dodgeSpeed;

            // Start coroutine to restore normal movement after the dodge duration
            StartCoroutine(RestoreNormalMovement(dodgeDuration));
        }
    }

    private IEnumerator RestoreNormalMovement(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Reset velocity to normal after dodge
        isRolling = false;
        my_Rigidbody.velocity = Vector2.zero; // Stops the boost
    }
}

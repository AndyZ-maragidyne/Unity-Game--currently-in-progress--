using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRightEnemy : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of movement
    public float moveRange = 5f; // Range of left-right movement

    private Vector2 startPosition; // Starting position of the enemy

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.PingPong(Time.time * moveSpeed, moveRange) - moveRange / 2f;
        transform.position = new Vector2(startPosition.x + newPosition, transform.position.y);
    }
}

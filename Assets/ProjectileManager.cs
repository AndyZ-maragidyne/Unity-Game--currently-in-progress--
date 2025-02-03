using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{

    public float deadZoneX = 45;
    public float deadZoneNX = -45;
    public float deadZoneNY = -30;
    public float deadZoneY = 30;
    public int damage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < deadZoneNX || transform.position.x > deadZoneX || transform.position.y < deadZoneNY || transform.position.y > deadZoneY)
        {
            Destroy(gameObject);
        }
    }
}

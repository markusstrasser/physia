using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    // Expose bullet prefab and speed in the inspector
    [Tooltip("Bullet Prefab")]
    public GameObject bulletPrefab;

    [Tooltip("Bullet Speed")]
    public float bulletSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Check if R key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Instantiate bullet at enemy's position and rotation
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Get the Rigidbody component of the bullet
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // If the bullet has a Rigidbody component
            if (rb != null)
            {
                // Fire the bullet in the direction the enemy is facing
                rb.velocity = transform.forward * bulletSpeed;
            }
        }
    }
}
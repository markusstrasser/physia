using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float spawnInterval = 5.0f; // Time between spawns
    public float initialVelocity = 10.0f; // Initial velocity of the rocks
    public float spawnHeightOffset = 1.0f; // Height offset for spawning from the capsule's top
    public float rockRadius = 0.5f; // Radius of the rocks
    public float rockMass = 1.0f; // Mass of the rocks
    public GameObject rock;
    private void Start()
    {
        StartCoroutine(SpawnRocks());
        ObjectManager.Instance.RegisterObject(gameObject, 100f, 15f);
    }

    private IEnumerator SpawnRocks()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            rock.transform.position = transform.position + transform.up * (transform.localScale.y + spawnHeightOffset);
            rock.transform.localScale = Vector3.one * (rockRadius * 2); // Scale based on radius

            // Add Rigidbody and set properties
            Rigidbody rb = rock.GetComponent<Rigidbody>();
            rb.mass = rockMass;
             
            // Direction the capsule is facing, elevated by 45 degrees
            Vector3 shootDirection = Quaternion.AngleAxis(45, transform.right) * transform.forward;
            rb.velocity = shootDirection * initialVelocity;
        }
    }
}
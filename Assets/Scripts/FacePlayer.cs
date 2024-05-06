using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    // Reference to the player's transform
    [Tooltip("Reference to the player's transform")]
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        // Check if playerTransform is not null
        if (playerTransform != null)
        {
            // Calculate the direction vector from the object to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Calculate the rotation needed to face the player
            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

            // Apply the rotation to the object
            transform.rotation = rotationToPlayer;
        }
    }
}
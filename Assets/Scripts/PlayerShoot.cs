using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject arrowPrefab; // Assign in Inspector
    public float shootingForce = 5;
    private bool isPressed = false;
    private float pressedTimer = 0;

    [SerializeField] private Transform Spawnpoint;
    void Update()
    {
        //todos getkeydown, up refactor
        if (Input.GetKey(KeyCode.E))
        {
            isPressed = true;
            pressedTimer += Time.deltaTime;
            
        }
        else
        {
            if (isPressed)
            {
                ShootArrowTowardsCursor(Mathf.Clamp(pressedTimer * 5,1, 10));
            }
            isPressed = false;
            pressedTimer = 0;
        }
    }

    void ShootArrowTowardsCursor(float forceMultiplier)
    {
        // Convert mouse position into a world position on a plane at the player's position
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Vector3 direction = targetPoint - transform.position;
            direction.y = 0; // Ensure arrow travels horizontally
            direction = direction.normalized;

            GameObject newArrow = Instantiate(arrowPrefab, Spawnpoint.position, Quaternion.LookRotation(direction));
            newArrow.transform.forward = direction;
            Rigidbody rb = newArrow.GetComponent<Rigidbody>();
            rb.AddForce(direction * shootingForce * forceMultiplier);
        }
    }
}
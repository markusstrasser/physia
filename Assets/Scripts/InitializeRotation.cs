using UnityEngine;

public class InitializeRotation : MonoBehaviour
{
    [SerializeField] private Transform target; // Assign the player or target transform in the inspector

    void Start()
    {
        if (target != null)
        {
            // Adjust this as necessary depending on the model's forward vector
            Vector3 relativePos = target.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = toRotation;
        }
    }
}
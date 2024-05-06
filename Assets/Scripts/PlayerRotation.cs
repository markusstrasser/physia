using UnityEngine;
public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100.0f;
    private bool isRotating = false;

    void Update()
    {
        if (!isRotating) return;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void StartRotate() => isRotating = true;
    public void StopRotate() => isRotating = false;
}
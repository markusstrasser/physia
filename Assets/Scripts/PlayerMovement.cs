using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    void Update()
    {
        var moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);
    }
}
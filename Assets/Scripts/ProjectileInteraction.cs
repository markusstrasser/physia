using TMPro;
using UnityEngine;
public class ProjectileInteraction : MonoBehaviour
{
    [SerializeField] private TMP_Text textmesh;
    private Collider theOther;
    private DrawLine drawLine;

    private void Awake() => drawLine = GetComponent<DrawLine>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("projectile")) return;
        (theOther = other).enabled = false;
        Pauser.Instance.SetPause(true);
    }

    void Update()
    {
        if (drawLine == null || !Pauser.Instance.isPaused || theOther?.transform.parent == null) 
        {
            drawLine?.ToggleLine(false);
            return;
        }

        Vector3 midpoint = (transform.position + theOther.transform.parent.position) / 2;
        textmesh.transform.position = midpoint;
        float distance = Vector3.Distance(transform.position, theOther.transform.parent.position);
        textmesh.text = distance.ToString("F1") + " m";
        
        drawLine.ToggleLine(true, transform.position, theOther.transform.parent.position);
    }
}
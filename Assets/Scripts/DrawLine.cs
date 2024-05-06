using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer; // Renamed for clarity, as there's only one line renderer.
    [SerializeField]
    private float lineWidth = 0.05f; // Made line width a serialized field for easier adjustment in the editor.
    [SerializeField]
    private Color lineColor = Color.magenta; // Made line color a serialized field for easier adjustment.

    private void Awake() => SetupLineRenderer();
    public void ToggleLine(bool shouldDraw, Vector3 start = default, Vector3 end = default)
    {
        lineRenderer.enabled = shouldDraw;
        if (shouldDraw) DrawPermanentLine(start, end);
    }

    private void DrawPermanentLine(Vector3 start, Vector3 end)
    {
        if (lineRenderer != null) lineRenderer.SetPositions(new Vector3[] {start, end});
    }
    
    private void SetupLineRenderer()
    {
        // Uses the serialized fields instead of parameters to allow configuration through the editor.
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
            if (lineRenderer == null)
            {
                Debug.LogError("LineRenderer component not found!", this);
                return;
            }
        }

        // Configure the line renderer's appearance based on serialized field values.
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 2;
    }
}

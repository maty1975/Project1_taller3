using UnityEngine;

[ExecuteInEditMode]
public class RadiusVisualizer : MonoBehaviour
{
    public Color gizmoColor = Color.yellow;
    [Range(0.1f, 50f)]
    public float radius = 5f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

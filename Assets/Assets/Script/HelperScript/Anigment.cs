using UnityEngine;

public class Anigment : MonoBehaviour
{
    public LayerMask groundLayer;
    public float raycastHeight = 5f;

    void Start()
    {
        Align();
    }

    void Align()
    {
        // Start raycast from a more reliable position
        Vector3 rayOrigin = transform.position + Vector3.up * raycastHeight;
        Ray ray = new Ray(rayOrigin, Vector3.down);
        RaycastHit hit;

        // Use explicit parameter names to avoid confusion
        if (Physics.Raycast(ray, out hit, maxDistance: raycastHeight + 10f, layerMask: groundLayer))
        {
            // Position the zombie slightly above the hit point to avoid sinking
            transform.position = new Vector3(transform.position.x, hit.point.y + 0.1f, transform.position.z);
            Debug.Log($"Zombie {gameObject.name} aligned to ground at Y: {hit.point.y}");
        }
        else
        {
            Debug.LogWarning($"No ground detected under {gameObject.name} at position {transform.position}");
            // Visualize the ray for debugging
            Debug.DrawRay(rayOrigin, Vector3.down * (raycastHeight + 10f), Color.red, 2f);
        }
    }
}

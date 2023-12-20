using UnityEngine;

public static class Extensions
{
    private static readonly LayerMask layerMask = LayerMask.GetMask("Default");

    public static bool Raycast(this Rigidbody2D rb, Vector2 direction)
    {
        if (rb.isKinematic) 
        {
            return false;
        }

        float radius = 0.25f;
        float distance = 0.375f;

        RaycastHit2D hit = Physics2D.CircleCast(rb.position, radius, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rb;
    }

    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }

}

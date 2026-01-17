using UnityEngine;

/// <summary>
/// Utility class for calculating jump physics and reachable areas.
/// Used by debug visualizers and level design tools.
/// </summary>
public static class JumpCalculator
{
    /// <summary>
    /// Calculate maximum horizontal jump distance
    /// </summary>
    /// <param name="horizontalSpeed">Cart's horizontal movement speed</param>
    /// <param name="jumpForce">Initial jump velocity</param>
    /// <param name="gravity">Gravity scale (from Rigidbody2D or Physics2D settings)</param>
    /// <returns>Maximum horizontal distance in units</returns>
    public static float CalculateMaxJumpDistance(float horizontalSpeed, float jumpForce, float gravity)
    {
        float timeToApex = jumpForce / (Mathf.Abs(Physics2D.gravity.y) * gravity);
        float totalAirTime = timeToApex * 2f; // Time up + time down
        return horizontalSpeed * totalAirTime;
    }

    /// <summary>
    /// Calculate maximum jump height
    /// </summary>
    /// <param name="jumpForce">Initial jump velocity</param>
    /// <param name="gravity">Gravity scale</param>
    /// <returns>Maximum height in units</returns>
    public static float CalculateMaxJumpHeight(float jumpForce, float gravity)
    {
        // h = v² / (2g)
        float effectiveGravity = Mathf.Abs(Physics2D.gravity.y) * gravity;
        return (jumpForce * jumpForce) / (2f * effectiveGravity);
    }

    /// <summary>
    /// Calculate time to reach jump apex (highest point)
    /// </summary>
    public static float CalculateTimeToApex(float jumpForce, float gravity)
    {
        return jumpForce / (Mathf.Abs(Physics2D.gravity.y) * gravity);
    }

    /// <summary>
    /// Calculate total air time for a jump
    /// </summary>
    public static float CalculateTotalAirTime(float jumpForce, float gravity)
    {
        return CalculateTimeToApex(jumpForce, gravity) * 2f;
    }

    /// <summary>
    /// Generate array of points for jump trajectory visualization
    /// </summary>
    /// <param name="startPosition">Starting position of jump</param>
    /// <param name="horizontalSpeed">Horizontal movement speed</param>
    /// <param name="jumpForce">Initial jump velocity</param>
    /// <param name="gravity">Gravity scale</param>
    /// <param name="pointCount">Number of points to generate (more = smoother curve)</param>
    /// <returns>Array of Vector3 positions along the jump arc</returns>
    public static Vector3[] CalculateJumpTrajectory(Vector3 startPosition, float horizontalSpeed, float jumpForce, float gravity, int pointCount = 50)
    {
        Vector3[] points = new Vector3[pointCount];
        float totalTime = CalculateTotalAirTime(jumpForce, gravity);
        float effectiveGravity = Mathf.Abs(Physics2D.gravity.y) * gravity;

        for (int i = 0; i < pointCount; i++)
        {
            float t = (i / (float)(pointCount - 1)) * totalTime;

            // Kinematic equations:
            // x = x0 + vx * t
            // y = y0 + vy * t - 0.5 * g * t²
            float x = startPosition.x + (horizontalSpeed * t);
            float y = startPosition.y + (jumpForce * t) - (0.5f * effectiveGravity * t * t);

            points[i] = new Vector3(x, y, startPosition.z);
        }

        return points;
    }

    /// <summary>
    /// Calculate the landing position of a jump (assuming flat ground at same height)
    /// </summary>
    public static Vector3 CalculateLandingPosition(Vector3 startPosition, float horizontalSpeed, float jumpForce, float gravity)
    {
        float distance = CalculateMaxJumpDistance(horizontalSpeed, jumpForce, gravity);
        return new Vector3(startPosition.x + distance, startPosition.y, startPosition.z);
    }

    /// <summary>
    /// Calculate the bounding box of the reachable area
    /// </summary>
    public static Bounds CalculateReachableBounds(Vector3 startPosition, float horizontalSpeed, float jumpForce, float gravity)
    {
        float maxDistance = CalculateMaxJumpDistance(horizontalSpeed, jumpForce, gravity);
        float maxHeight = CalculateMaxJumpHeight(jumpForce, gravity);

        // Center of the reachable area
        Vector3 center = new Vector3(
            startPosition.x + maxDistance / 2f,
            startPosition.y + maxHeight / 2f,
            startPosition.z
        );

        // Size of the reachable area
        Vector3 size = new Vector3(maxDistance, maxHeight + Mathf.Abs(startPosition.y), 0.1f);

        return new Bounds(center, size);
    }

    /// <summary>
    /// Check if a target position is reachable from start position
    /// </summary>
    public static bool IsPositionReachable(Vector3 startPosition, Vector3 targetPosition, float horizontalSpeed, float jumpForce, float gravity, float tolerance = 0.5f)
    {
        Bounds reachable = CalculateReachableBounds(startPosition, horizontalSpeed, jumpForce, gravity);
        return reachable.Contains(targetPosition);
    }

    /// <summary>
    /// Get formatted string with jump statistics
    /// </summary>
    public static string GetJumpStats(float horizontalSpeed, float jumpForce, float gravity)
    {
        float maxDistance = CalculateMaxJumpDistance(horizontalSpeed, jumpForce, gravity);
        float maxHeight = CalculateMaxJumpHeight(jumpForce, gravity);
        float airTime = CalculateTotalAirTime(jumpForce, gravity);

        return $"Max Distance: {maxDistance:F2} units ({maxDistance * 100:F0}px)\n" +
               $"Max Height: {maxHeight:F2} units ({maxHeight * 100:F0}px)\n" +
               $"Air Time: {airTime:F2}s";
    }
}

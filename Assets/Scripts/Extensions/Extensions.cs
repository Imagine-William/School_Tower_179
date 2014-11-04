using UnityEngine;
using System.Collections;

public static class Extensions
{
    /// <summary>
    /// Sets the x position of the transform.
    /// </summary>
    /// <param name="x">The new x coordinate.</param>
    public static void SetPositionX(this Transform t, float x)
    {
        t.position = new Vector3(x, t.position.y, t.position.z);
    }

    /// <summary>
    /// Sets the y position of the transform.
    /// </summary>
    /// <param name="y">The new y coordinate.</param>
    public static void SetPositionY(this Transform t, float y)
    {
        t.position = new Vector3(t.position.x, y, t.position.z);
    }

    /// <summary>
    /// Sets the z position of the transform.
    /// </summary>
    /// <param name="z">The z coordinate.</param>
    public static void SetPositionZ(this Transform t, float z)
    {
        t.position = new Vector3(t.position.x, t.position.y, z);
    }
}
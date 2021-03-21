using System;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Vector3 position)
    {
        try
        {
            position.z = Camera.main.nearClipPlane;
            var result = Camera.main.ScreenToWorldPoint(position);
            return result;
        }
        catch (Exception e)
        {
            Debug.LogWarning("No hay camara");
            return Vector3.zero;
        }
    }
}

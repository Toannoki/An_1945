using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetTransform(Transform source)
    {
        transform.position = source.position;
        transform.rotation = source.rotation;
    }
}

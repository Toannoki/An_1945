using UnityEngine;

public class WatchingObject : MonoBehaviour
{

    public GameObject Target;
    void Update()
    {
        this.transform.LookAt(Target.transform.position);
    }
}

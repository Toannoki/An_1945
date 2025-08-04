using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent[] onTrigger;

    private int CurrentEvent =0;
    public Transform target; // Mục tiêu mà nhân vật cần nhìn về
    public float viewThreshold = 5f; // độ lệch cho phép (góc)

    public AudioSource JumpScare;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);
        onTrigger[CurrentEvent].Invoke(); 
    }
    private void OnTriggerStay(Collider other)
    {
        if (IsLookingAt(other.transform, target, viewThreshold))
        {
            Debug.Log("Triggered by: " + other.name);
            MoveWithoutNavMesh move = target.GetComponentInParent<MoveWithoutNavMesh>();
            move.StartMoving(1);
            JumpScare.time = 0.5f;
            JumpScare.Play();
            onTrigger[1].Invoke();
            Interactable inter = target.GetComponentInParent<Interactable>();
            inter.enabled = false;
        }
    }
    bool IsLookingAt(Transform self, Transform target, float threshold)
    {
        if (target == null)
            return false;
        Vector3 directionToTarget = (target.position - self.position).normalized;
        float angle = Vector3.Angle(self.forward, directionToTarget);

        return angle < threshold;
    }
    public void SetEvent(int ev)
    {
        CurrentEvent = ev;
    }
}

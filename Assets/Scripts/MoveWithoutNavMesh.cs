using System.Linq;
using UnityEngine;

[System.Serializable]
public class PathOption
{
    public Transform[] waypoints;
    public bool endWithSit = false;
    public float speed = 2f;
}
public class MoveWithoutNavMesh : MonoBehaviour
{
    public PathOption[] pathList;
    private Transform[] currentPath;
    private bool endWithSit = false;
    private float currentSpeed = 2f;

    private int currentWaypointIndex = 0;
    private Animator animator;

    public Transform sitPoint;
    public float stoppingDistance = 0.1f;

    public bool isAngry = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        enabled = false; // chỉ di chuyển khi được gọi StartMoving
    }

    public void StartMoving(PathOption pathOption)
    {
        currentPath = pathOption.waypoints;
        endWithSit = pathOption.endWithSit;
        currentSpeed = pathOption.speed;

        currentWaypointIndex = 0;
        enabled = true;
    }
    public void StartMoving(int index)
    {
        if (index >= 0 && index < pathList.Length)
        {
            StartMoving(pathList[index]);
        }
        else
        {
            Debug.LogWarning("Index path không hợp lệ: " + index);
        }
    }
    void Update()
    {
        if (animator != null)
            if (isAngry)
                animator.SetBool("isAngry", true);

        if (currentPath == null || currentWaypointIndex >= currentPath.Length) return;

        Transform target = currentPath[currentWaypointIndex];
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            if (animator != null)
            {
                animator.SetBool("isMove", true);
            }
        }
        else
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= currentPath.Length)
            {
                if (endWithSit && sitPoint != null)
                {
                    transform.position = sitPoint.position;
                    transform.rotation = sitPoint.rotation;
                }
                if (animator != null)
                {
                    animator.SetBool("isMove", false);
                    animator.SetBool("isSit", endWithSit);
                }
                enabled = false;
            }
        }
    }
}

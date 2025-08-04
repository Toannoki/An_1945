using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class CheckCutScene : MonoBehaviour
{
    public PlayableDirector director;
    public UnityEvent onInteraction;
    public bool islockMouse = true;

    void Start()
    {
        director.stopped += OnTimelineEnded;
    }

    // Update is called once per frame
    void OnTimelineEnded(PlayableDirector pd)
    {
        if(islockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

            Debug.Log("Timeline đã kết thúc, thực hiện hành động tiếp theo...");
            onInteraction.Invoke();

    }
}

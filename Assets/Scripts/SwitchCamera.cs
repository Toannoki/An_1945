using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Camera_1;

    public Interactable Obj;

    public void Start()
    {
    }
    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            SwitchBack();   
        }
    }
    public void Switch()
    {
        Camera_1.SetActive(false);
        gameObject.SetActive(true);
    }

    public void SwitchBack()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Obj !=null)
            Obj.DisableInteractable();
        Camera_1.SetActive(true);
        gameObject.SetActive(false);
    }
}

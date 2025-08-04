using System.Collections;
using System.Dynamic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public UnityEvent[] onInteraction2;

    public GameObject ItemOnHand;
    private int CurrentEvent =0;

    void Start()
    {
        
    }
    public void Interact()
    {
            onInteraction2[CurrentEvent].Invoke();
    }

    public void EnableInteractable()
    {
        this.enabled = true;
    }
    public void DisableInteractable()
    {
        this.enabled = false;
    }

    public void SetEvent(int ev)
    {
        CurrentEvent = ev;
    }
}

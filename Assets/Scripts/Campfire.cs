using UnityEngine;

public class Campfire : MonoBehaviour
{
    GameObject player;
    private bool isSitting = false;
    public GameObject cam;
    public GameObject sittingplayer;
    void Start()
    {
        player = GameObject.FindWithTag("Player2");   
    }

    public void Sitting()
    {
        if (!isSitting)
        {
            isSitting = true;
            player.SetActive(false);
            sittingplayer.SetActive(true);
            cam.SetActive(true);
        }
        else
        {
            isSitting = false;
            player.SetActive(true);
            sittingplayer.SetActive(false);
            cam.SetActive(false);
        }

    }
}

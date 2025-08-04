using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SetingsMenu SettingMenu;
    public void Load_Scene(string sceneName)
    {
        Debug.Log("Đang load");
        SceneManager.LoadScene(sceneName);
    }
    void Update()
    {
        if (SettingMenu != null)
            if (Input.GetKeyDown(KeyCode.Escape))
                if (SettingMenu.gameObject.activeSelf)
                    SettingMenu.BackToGame();
                else
                    SettingMenu.Pause();      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //quit butonu eventi
    public void QuitGame()
    {
        Application.Quit();
    }
    //hangi sahne açılsın sırasına göre build settingsten ekledik ve main menu eventsten buttonalra aktardık
    public void LoadGame(int index)
    {
        SceneManager.LoadScene(index);
    }
}
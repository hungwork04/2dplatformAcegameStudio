using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject levelpanel;
    public void TurnOnLvPanel()
    {
        levelpanel.SetActive(true);
    }
    public void TurnOffLvPanel()
    {
        levelpanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void loadlv(int index)
    {
        SceneManager.LoadScene(index);
    }
}

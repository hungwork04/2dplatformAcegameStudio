using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Level Value")]
    public int Score;
    public int Level;
    public int Money;
    public int Time;
   
    [Space(10)]
    public Transform StartPoint;
    public GameObject player;
    private void Start()
    {
        player.transform.position = StartPoint.position;
    }
    public static GameManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
             Destroy(instance.gameObject);
        }
        instance = this;
    }
    private void Update()
    {
        if (player.transform.position.y< -7)
        {
           // Debug.LogWarning("Check");
            //player.transform.position = StartPoint.position;
            player.SetActive(false);
            ObserverManager.OnPlayerDead?.Invoke("LOSE");
        }
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

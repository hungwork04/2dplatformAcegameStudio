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
    bool isSeperate ;
    private void OnEnable()
    {
        isSeperate = false;
    }
    private void Update()
    {
        if (player.transform.position.y< -7)
        {
           // Debug.LogWarning("Check");
            player.SetActive(false);
            if (!isSeperate)
            {
                DataController.Money = Mathf.FloorToInt(0.7f * DataController.Money);
                Debug.Log(DataController.Money);
                isSeperate = true;
            }
            ObserverManager.OnPlayerEndGame?.Invoke("LOSE");
        }
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

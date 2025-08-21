using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;
    public int Level;
    public int Money;
    public int Time;

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
        if (player.transform.position.y< -5)
        {
           // Debug.LogWarning("Check");
            player.transform.position = StartPoint.position;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIinGame : MonoBehaviour
{
    [Header("Level Panel")]
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI TimeTxt;
    public TextMeshProUGUI LevelTxt;
    public TextMeshProUGUI MoneyTxt;
    [Space(10)]
    [Header("Endgame Panel")]
    public GameObject EndgamePanel;
    public TextMeshProUGUI ResultTxt;
    private void OnEnable()
    {
        ObserverManager.OnUpdateScore += updateScoreUI;
        ObserverManager.OnPlayerDead += ShowUIEndGame;

    }
    private void OnDisable()
    {
        ObserverManager.OnUpdateScore -= updateScoreUI;
        ObserverManager.OnPlayerDead -= ShowUIEndGame;

    }
    public void updateScoreUI()
    {
        ScoreTxt.text =GameManager.instance.Score.ToString();
        TimeTxt.text =GameManager.instance.Time.ToString();
        LevelTxt.text =GameManager.instance.Level.ToString();
        MoneyTxt.text =GameManager.instance.Money.ToString();
    }
    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit(){
        SceneManager.LoadScene(0);
    }
    public void ShowUIEndGame(string result){
        EndgamePanel.SetActive(true);
        ResultTxt.text = result;
    }
}

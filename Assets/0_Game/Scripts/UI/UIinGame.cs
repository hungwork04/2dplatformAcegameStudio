using DG.Tweening;
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
    public RectTransform EndgamePanel;
    public TextMeshProUGUI ResultTxt;
    private void Start()
    {
        EndgamePanel.localScale = Vector3.zero;
    }
    private void OnEnable()
    {
        ObserverManager.OnUpdateScore += updateScoreUI;
        ObserverManager.OnPlayerEndGame += ShowUIEndGame;
        updateScoreUI();
    }
    private void OnDisable()
    {
        ObserverManager.OnUpdateScore -= updateScoreUI;
        ObserverManager.OnPlayerEndGame -= ShowUIEndGame;
    }
    public void updateScoreUI()
    {
        //ScoreTxt.text =GameManager.instance.Score.ToString();
        //TimeTxt.text =GameManager.instance.Time.ToString();
        //LevelTxt.text =GameManager.instance.Level.ToString();
        //MoneyTxt.text =GameManager.instance.Money.ToString();

        ScoreTxt.text = DataController.HighScore.ToString();
        //TimeTxt.text = PrefData.HighScore.ToString();
        LevelTxt.text = DataController.Level.ToString();
        MoneyTxt.text = DataController.Money.ToString();
    }
    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit(){
        SceneManager.LoadScene(0);
    }
    public void ShowUIEndGame(string result){
        EndgamePanel.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        ResultTxt.text = result;
    }
    private void OnDestroy()
    {
        DOTween.Kill(gameObject); 
    }

}

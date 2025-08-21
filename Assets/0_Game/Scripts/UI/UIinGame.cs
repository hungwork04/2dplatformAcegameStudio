using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIinGame : MonoBehaviour
{
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI TimeTxt;
    public TextMeshProUGUI LevelTxt;
    public TextMeshProUGUI MoneyTxt;

    private void OnEnable()
    {
        ObserverManager.OnUpdateScore += updateScoreUI;
    }
    private void OnDisable()
    {
        ObserverManager.OnUpdateScore -= updateScoreUI;
    }
    public void updateScoreUI()
    {
        ScoreTxt.text =GameManager.instance.Score.ToString();
        TimeTxt.text =GameManager.instance.Time.ToString();
        LevelTxt.text =GameManager.instance.Level.ToString();
        MoneyTxt.text =GameManager.instance.Money.ToString();
    }
}

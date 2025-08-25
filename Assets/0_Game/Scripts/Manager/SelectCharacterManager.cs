using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacterManager : MonoBehaviour
{

    public List<PlayerManager.CharacterInfor> chas = new List<PlayerManager.CharacterInfor>();
    [Space]
    [Header("Select Character UI")]
    public Image ava;
    public int chooseIndex ;
    public GameObject selectPanel;

    private void Start()
    {
        chooseIndex = DataController.SelectedSkin;
        ava.sprite = chas[chooseIndex].Sprite;
        PlayerManager.player.animatorController = chas[chooseIndex].animatorController;
        PlayerManager.player.Sprite = chas[chooseIndex].Sprite;
    }
    public void SwitchCharacter()
    {
        if (chooseIndex + 1 >= chas.Count)
        {
            chooseIndex=0;
        }else
            chooseIndex++;
        ava.sprite = chas[chooseIndex].Sprite;
    }
    public void SelectCharacter()
    {
        PlayerManager.player.animatorController = chas[chooseIndex].animatorController;
        PlayerManager.player.Sprite = chas[chooseIndex].Sprite;
        DataController.SelectedSkin = chooseIndex;
        selectPanel.SetActive(false);
    }
    public void TurnOnSelectPanel()
    {
        selectPanel.SetActive(true);

    }

}

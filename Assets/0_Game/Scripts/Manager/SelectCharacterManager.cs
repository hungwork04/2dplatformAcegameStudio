using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacterManager : MonoBehaviour
{
    [Serializable]
    public class CharacterInfor
    {
        public string name;
        [SerializeField] public RuntimeAnimatorController animatorController;//?
        public Sprite Sprite;
    }
    public List<CharacterInfor> chas = new List<CharacterInfor>();
    public Image ava;
    public static int chooseIndex = 0;
    public GameObject selectPanel;
    private void Start()
    {
        DontDestroyOnLoad(this);  
        chooseIndex = 0;
        ava.sprite = chas[chooseIndex].Sprite;
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
        selectPanel.SetActive(false);
    }
    public void TurnOnSelectPanel()
    {
        selectPanel.SetActive(true);

    }

}

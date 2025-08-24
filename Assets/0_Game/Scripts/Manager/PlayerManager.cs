using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Serializable]
    public class CharacterInfor
    {
        public string name;
        [SerializeField] public RuntimeAnimatorController animatorController;//?
        public Sprite Sprite;
    }
    public static CharacterInfor player = new CharacterInfor();
    public static PlayerManager Instance;
    private void Awake()
    {
        // Nếu đã có instance khác tồn tại thì hủy cái mới
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Gán instance
        Instance = this;

        // Giữ lại qua các scene
        DontDestroyOnLoad(gameObject);
    }
}

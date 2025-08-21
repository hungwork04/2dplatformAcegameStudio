using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public enum ApplyEffectType
{
    Child,
    Parent
}

[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class ButtonAttribute : PropertyAttribute {
}

public class ButtonEffectLogic : Button
{
    [SerializeField] private Transform renderTransform;
    [SerializeField] private ApplyEffectType applyEffectType = ApplyEffectType.Child;
    
    
    public bool hasEffect = true;
    public bool hasSound = true;
    public UnityEvent onEnter = new UnityEvent(), 
        onDown = new UnityEvent(),
        onExit = new UnityEvent(),
        onUp = new UnityEvent();
    Vector3 initScale;
    
    

    protected override void Awake()
    {
        initScale = Vector3.one* 2.5114f;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if(hasSound) AudioManager.Instance.PlayButtonSound();
        base.OnPointerDown(eventData);
        onDown.Invoke();
        EffectDown();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        onEnter.Invoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        onUp.Invoke();
        EffectUp();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        onExit.Invoke();
    }


    void EffectDown()
    {
        if (hasEffect)
        {
            transform.localScale = initScale;
            transform.DOScale(initScale * 1.1f, 0.2f).SetEase(Ease.Linear);
        }
    }

    void EffectUp()
    {
        if (hasEffect)
        {
            transform.localScale = initScale * 1.1f;
            transform.DOScale(initScale, 0.2f).SetEase(Ease.Linear);
        }
    }
    
    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (applyEffectType == ApplyEffectType.Child)
        {
            renderTransform.DOKill();
        }
        else
        {
            transform.DOKill();
        }
    }
    
    #if UNITY_EDITOR

    [Header("DEV")]
    public bool IS_REFRESH = true;

    protected override void OnValidate()
    {
        base.OnValidate();
        if (IS_REFRESH)
        {
            IS_REFRESH = false;
            renderTransform = transform.GetChild(0);
        }
        
    }

    #endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(ButtonEffectLogic))]
public class ButtonEffectLogicEditor : Editor {
    ButtonEffectLogic mtarget;
    private void OnEnable()
    {
        mtarget = target as ButtonEffectLogic;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

    }
}
#endif

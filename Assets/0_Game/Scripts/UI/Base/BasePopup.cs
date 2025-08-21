using DG.Tweening;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    [SerializeField] protected CanvasGroup main;

    [SerializeField] private ButtonEffectLogic btnClose;

    public bool isShow;
    
    protected virtual void Awake()
    {
        if(btnClose != null) btnClose.onClick.AddListener(Hide);
    }

    public virtual void Show()
    {
        isShow = true;
        gameObject.SetActive(true);
        main.DOFade(1f, .5f).From(0);
        ButtonCloseEffect();
    }

    public virtual void Hide()
    {
        main.DOFade(0f, .5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
        isShow = false;
    }
    
    protected void ButtonCloseEffect()
    {
        if(btnClose == null) return;
        btnClose.transform.localScale = Vector3.zero;
        DOVirtual.DelayedCall(1.75f, () =>
        {
            if (isShow) btnClose.transform.DOScale(1f, .7f);
        });
    }

    protected virtual void OnDisable()
    {
        btnClose.transform.DOKill();
        main.DOKill();
    }
    
    #if UNITY_EDITOR

    [Button]
    public virtual void BASE_POPUP_INIT()
    {
        main = Utils.FindInChildren(gameObject, "Main").GetComponent<CanvasGroup>();
        btnClose = Utils.FindInChildren(gameObject, "ButtonClose").GetComponent<ButtonEffectLogic>();
        
        this.SetDirty();
    }
    
    #endif
}

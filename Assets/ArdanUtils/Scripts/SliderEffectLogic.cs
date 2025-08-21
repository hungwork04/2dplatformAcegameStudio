using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderEffectLogic : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public UnityEvent onEnter = new UnityEvent(),
        onDown = new UnityEvent(),
        onExit = new UnityEvent(),
        onUp = new UnityEvent();

    public bool hasEffect;
    
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImageSlider, icon;
    [SerializeField] private TextMeshProUGUI sliderText;

    [SerializeField] private Vector3 iconRotationEffect = new (0, 0, 20);
    [SerializeField] private Vector3 iconScaleEffect = Vector3.one * .9f;

    private Vector3 _curIconScale;
    
    private void Start()
    {
        //Wait Loaded Data
        fillImageSlider.color = Color.Lerp(Color.red, Color.green, slider.value);
        slider.onValueChanged.AddListener( SliderEffectChange);
        sliderText.text = (int)(slider.value * 100 ) + "%"; 

        _curIconScale = icon.transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onDown.Invoke();
        EffectEnter();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        onEnter.Invoke();
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        onExit.Invoke();
      
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        onUp.Invoke();
        EffectExit();
    }

    private void EffectEnter()
    {
        if(!hasEffect) return;
        
        var iconTransform = icon.transform;
        iconTransform.transform.localScale = iconScaleEffect;
        iconTransform.transform.localRotation = Quaternion.Euler(iconRotationEffect);
        sliderText.DOFade(1f, .5f).SetUpdate(true);
    }

    private void EffectExit()
    {
        if(!hasEffect) return;

        var iconTransform = icon.transform;
        iconTransform.localScale = _curIconScale;
        iconTransform.localRotation = Quaternion.identity;
        sliderText.DOFade(0, .5f).SetUpdate(true);
    }

    private void SliderEffectChange(float value)
    {
        if(!hasEffect) return;
        
        fillImageSlider.color = Color.Lerp(Color.red, Color.green, value);
        sliderText.text = (int)(value * 100 ) + "%"; 
    }

    private void OnDisable()
    {
        sliderText.DOKill();
    }

    #if UNITY_EDITOR
    
    [Button]
    private void DEV_INIT_SLIDER()
    {
        slider = GetComponent<Slider>();
        fillImageSlider = slider.fillRect.GetComponent<Image>();

        foreach (Transform child in transform.parent)
        {
            if(child.name.Contains("Icon") || icon == null)
            {
                icon = child.GetComponent<Image>();
            } 
            
            if (child.name.Contains("Text") || sliderText == null)
            {
                sliderText = child.GetComponent<TextMeshProUGUI>();
            }
        }
        
        
    }

    #endif
}

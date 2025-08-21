using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class UILoading : BasePanel
{
    [Header("LOADING_PANEL")]
    [SerializeField] private Image loadingFadeImage;
    [SerializeField] private float loadingHalfDuration;

    private bool isLoading;

    public void CallLoadingShow(Action action, bool autoHide = true)
    {
        if(isLoading) return;
        base.Show();
        isLoading = true;
        gameObject.SetActive(true);
        loadingFadeImage.DOFade(1, loadingHalfDuration).From(0).OnComplete(() =>
        {
            action?.Invoke();
            if (autoHide)
            {
                CallLoadingHide();
            }
        });
    }

    public void CallLoadingHide()
    {
        loadingFadeImage.DOFade(0, loadingHalfDuration).OnComplete(Hide);
    }

    public override void Hide()
    {
        base.Hide();
        isLoading = false;
    }

}

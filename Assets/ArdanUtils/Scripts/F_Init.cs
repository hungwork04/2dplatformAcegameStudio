using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class F_Init : MonoBehaviour
{
	public GameObject loadingCanvas;
	[SerializeField] Image process;

	private bool LoadComplete;

	private void Awake()
	{
		Application.targetFrameRate = 60;
		DontDestroyOnLoad(gameObject);
	}

	private IEnumerator Start()
	{
		StartCoroutine(LoadSceneAsync(1));
		loadingCanvas.SetActive(true);

		float timeWaitAOA = 3;
#if UNITY_EDITOR
		timeWaitAOA = 3;
		process.DOFillAmount(.9f, timeWaitAOA).From(0);
#elif !UNITY_EDITOR
        process.DOFillAmount(.9f, timeWaitAOA).From(0);
#endif
		yield return Yielder.Get(timeWaitAOA);
		process.DOKill();
		process.DOFillAmount(1, .9f).SetEase(Ease.Linear);
		
		yield return Yielder.Get(.75f);
		LoadComplete = true;
		yield return Yielder.Get(.25f);
		loadingCanvas.SetActive(false);
	}

	IEnumerator LoadSceneAsync(int scene)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(scene);
		async.allowSceneActivation = false;
		yield return Yielder.Get(1f);
		
		while (async.progress < 0.9f || !LoadComplete)
		{
			yield return null;
		}
		
		async.allowSceneActivation = true;
	}


}

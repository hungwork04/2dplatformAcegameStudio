using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UINotify : MonoBehaviour
{
    [SerializeField] private GameObject[] notifies;
    [SerializeField] private Text[] txtNotifies;
    private int _index = 0;
    
    public void Notify(string s)
    {
        if (notifies[_index].activeInHierarchy)
        {
            return;
        }
        txtNotifies[_index].text = s;
        var noti = notifies[_index];
        noti.SetActive(true);
        _index = (_index + 1) % notifies.Length;
        DOVirtual.DelayedCall(1.5f, () =>
        {
            noti.SetActive(false);
        });
    }
}

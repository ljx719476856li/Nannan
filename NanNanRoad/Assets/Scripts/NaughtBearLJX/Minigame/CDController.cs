using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDController : MonoBehaviour
{
    public Button btn;
    bool btnActive = true;
    
    IEnumerator Timer()
    {
        btn.gameObject.SetActive(!btnActive);
        yield return new WaitForSeconds(2.0f);
        Debug.Log(string.Format("Timer2 is up !!! time=${0}", Time.time));
        btn.gameObject.SetActive(btnActive);
    }

    IEnumerator SetBtnActive()
    {
        gameObject.SetActive(!btnActive);
        yield return null;
    }

    public void OnClicked()
    {
        if (this.gameObject.activeSelf)
            StartCoroutine(Timer());
        else
            return;
    }
}

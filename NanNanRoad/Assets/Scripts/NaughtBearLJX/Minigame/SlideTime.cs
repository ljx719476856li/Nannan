using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTime : MonoBehaviour
{
    public GameObject Stone;
    public GameObject go;
    //public Vector3 startPos;
    public Vector2 threshold;
    public Vector2 sucessRange;
    public Vector3 endPos;
    private Vector3 pos;

    private void Start()
    {
        Debug.Log(transform.position);
        isMoved = true;
        isContron = false;
        //UtilitiesGame.Instance.RefreshPos(ref endPos);

    }
    float timePrecentage = 0.0f;
    bool isMoved;
    bool isContron;
    private void Update()
    {
        if (isMoved == true)
        {
            if (timePrecentage < 1.0f)
            {
                timePrecentage += Time.deltaTime / 0.2f;
                transform.position = Vector3.Lerp(transform.position, endPos, timePrecentage);
            }
            else
            {
                timePrecentage = 0.0f;
                UtilitiesGame.Instance.RefreshPs(ref endPos, threshold);
            }
        }
        //if (isContron == true)
        //{
        //    if (timePrecentage < 1.0f)
        //    {
        //        timePrecentage += Time.deltaTime / 0.2f;
        //        transform.position = Vector3.Lerp(transform.position, endPos, timePrecentage);
        //    }
        //    else
        //    {
        //        timePrecentage = 0.0f;
        //        UtilitiesGame.Instance.RefreshPos2(ref endPos);
        //    }
        //}
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            Debug.Log(string.Format("Timer2 is up !!! time=${0}", Time.time));
            go.SetActive(false);
            Stone.SetActive(false);
        }
    }

    IEnumerator Test()
    {
        float timePrecentage2 = 0;
        while (timePrecentage2 < 1.0f)
        {
            timePrecentage2 += Time.deltaTime / 0.2f;
            transform.position = Vector3.Lerp(transform.position, endPos, timePrecentage2);
            yield return null;
        }
    }

    public void OnClicked()
    {
        if (sucessRange.x <= transform.position.x && transform.position.x <= sucessRange.y)
        {
            isContron = true;
            UtilitiesGame.Instance.RefreshPos2(ref endPos);
            StartCoroutine(Test());
            StartCoroutine(Timer());
            Debug.Log("OnClicked");
        }
    }
    public void OnButtonUp()
    {
        isContron = false;
        if (sucessRange.x <= transform.position.x && transform.position.x <= sucessRange.y)
        {
            isMoved = true;
            Debug.Log("OnButtonUp");
            //StartCoroutine(Timer());

        }
    }

}

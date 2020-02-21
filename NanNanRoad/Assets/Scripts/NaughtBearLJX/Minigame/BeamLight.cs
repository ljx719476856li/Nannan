using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLight : MonoBehaviour
{
    public Camera cam;
    public GameObject Road;
    public GameObject go;
    //public Vector3 startPos;
    public Vector2 sucessRange;
    public Vector3 endPos;
    private Vector3 pos;
    private Stone stone;

    private void Start()
    {
        //0 - -17.6
        stone = new Stone();
        Debug.Log(transform.position);
        endPos = UtilitiesGame.Instance.RefreshPosLight(transform.position);
    }

    float timePrecentage = 0.0f;
    private void Update()
    {
        if (timePrecentage < 1.0f)
        {
            timePrecentage += Time.deltaTime / 0.8f;
            transform.position = Vector3.Lerp(transform.position, endPos, timePrecentage);
        }
        else
        {
            timePrecentage = 0.0f;
            endPos = UtilitiesGame.Instance.RefreshPosLight(transform.position);
        }
    }

    IEnumerator Test()
    {
        float timePrecentage2 = 0;
        while (timePrecentage2 < 1.0f)
        {
            timePrecentage2 += Time.deltaTime / 0.2f;
            transform.position = Vector3.Lerp(transform.position, endPos, timePrecentage2);
            stone.HP -= 1;
            yield return null;
        }
    }

    public void OnClicked()
    {
        if (stone.HP <= 0)
        {
            go.SetActive(false);
            Road.SetActive(false);
            cam.gameObject.SetActive(false);
        }

        UtilitiesGame.Instance.RefreshPos4(ref endPos);
        Debug.Log(endPos.x);
        StartCoroutine(Test());
    }

    public void OnButtonUp()
    {
        Debug.Log("23333");
    }
}

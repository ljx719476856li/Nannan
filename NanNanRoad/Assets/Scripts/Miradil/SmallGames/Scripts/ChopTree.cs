using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class ChopTree : MonoBehaviour
{
    public event Action OnWin;
    public event Action OnLose;

    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] float hp = 5;
    [SerializeField] float cdTime = 1;
    [SerializeField] int chance = 10;

    RectTransform okArea;
    RandomCursor cursor;
    float currentCd;
    bool won;

    void Start()
    {
        okArea = transform.GetChild(0).Find("OkArea").GetComponent<RectTransform>();
        cursor = transform.GetChild(0).Find("Cursor").GetComponent<RandomCursor>();
        hpText.SetText("HP: " + hp);
        currentCd = cdTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (won) return;
        currentCd += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && currentCd >= cdTime)
        {
            chance--;
            cursor.Stop(0.5f);
            currentCd = 0;
            float cursorPos = cursor.self.anchoredPosition.x;
            if (okArea.Contains(cursorPos))
            {
                if (--hp <= 0)
                {
                    won = true;
                    OnWin?.Invoke();    
                    transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutQuart).OnComplete(
                        delegate 
                        {
                            Destroy(gameObject);
                        });
                }
                hpText.SetText("HP: " + hp);
                hpText.transform.DOShakeScale(0.25f);
            }
            else
            {
                if (chance <= 0)
                {
                    OnLose?.Invoke();
                }
            }
        }
    }
}

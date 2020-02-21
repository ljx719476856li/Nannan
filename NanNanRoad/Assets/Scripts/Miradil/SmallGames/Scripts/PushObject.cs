using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public event Action OnWin;
    public event Action OnLose;

    [SerializeField] float winDuration = 5;
    [SerializeField] TextMeshProUGUI durationText;

    RectTransform okArea;
    RandomCursor cursor;
    float currentDuration;
    bool won;

    void Start()
    {
        okArea = transform.GetChild(0).Find("OkArea").GetComponent<RectTransform>();
        cursor = transform.GetChild(0).Find("Cursor").GetComponent<RandomCursor>();
        durationText.SetText("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        if (won) return;
        float cursorPos = cursor.self.anchoredPosition.x;
        if (okArea.Contains(cursorPos))
        {
            currentDuration += Time.deltaTime;
            if (currentDuration >= winDuration)
            {
                won = true;
                OnWin?.Invoke();
                transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutQuart).OnComplete(
                    delegate
                    {
                        Destroy(gameObject);
                    });
            }
        }
        else
        {
            currentDuration = 0;
        }
        durationText.SetText(Math.Round(currentDuration, 2).ToString());
    }
}

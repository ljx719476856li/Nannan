using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillRoad : MonoBehaviour
{
    public event Action OnWin;
    public event Action OnLose;

    [SerializeField] float winDuration = 5;
    [SerializeField] TextMeshProUGUI durationText;

    RectTransform okArea;
    float currentDuration;
    RoadScaler cursor;
    bool won;

    void Start()
    {
        okArea = transform.GetChild(0).Find("OkArea").GetComponent<RectTransform>();
        cursor = transform.GetChild(0).Find("Scaler").GetComponent<RoadScaler>();
    }

    void Update()
    {
        if (won) return;
        float cursorPos = cursor.GetPos();
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

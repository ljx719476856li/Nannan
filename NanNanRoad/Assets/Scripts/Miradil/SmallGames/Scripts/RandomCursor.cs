using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RandomCursor : MonoBehaviour
{
    //移动速度的随机范围
    [SerializeField]
    Vector2 randomSpeedRange = new Vector2(50, 500);
    //改变方向频率的随机范围
    [SerializeField]
    Vector2 changeDirFreqRange = new Vector2(0.2f, 0.75f);
    [HideInInspector]
    public RectTransform self;

    Rect bound;
    //-1: L, 1: R
    short currentDirection = -1;
    float currentSpeed;
    float currentDuration;

    float stopDuration;

    public void Stop(float duration)
    {
        stopDuration = duration;
        self.DOShakeScale(0.2f, 0.75f);
    }

    void Start()
    {
        self = GetComponent<RectTransform>();
        ReScan();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopDuration > 0)
        {
            stopDuration -= Time.deltaTime;
            return;
        }
        if (currentDuration > 0)
        {
            currentDuration -= Time.deltaTime;
            Vector2 newPos = self.anchoredPosition;
            newPos.x += currentSpeed * currentDirection * Time.deltaTime;
            self.anchoredPosition = newPos;
        }
        else
        {
            ReScan();
        }
    }

    private void ReScan()
    {
        bound = transform.parent.GetComponent<RectTransform>().rect;
        currentDuration = GetRand(changeDirFreqRange);
        currentSpeed = GetRand(randomSpeedRange);
        currentDirection = (short)(currentDirection * -1);
        float finalPos = self.anchoredPosition.x + currentSpeed * currentDirection * currentDuration;
        if (finalPos < bound.xMin || finalPos > bound.xMax)
        {
            finalPos = Mathf.Clamp(finalPos, bound.xMin, bound.xMax);
            currentDuration = (finalPos - self.anchoredPosition.x) / (currentDirection * currentSpeed);
        }
    }

    float GetRand(Vector2 range)
    {
        return UnityEngine.Random.Range(range.x, range.y);
    }
}

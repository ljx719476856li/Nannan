using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScaler : MonoBehaviour
{
    [SerializeField] float shrinkSpeed = -500;
    [SerializeField] Vector2 expandSpeedRange = new Vector2(400, 800);
    [SerializeField] float expandLerpSpd = 5;

    [HideInInspector]
    public RectTransform self;
    float currentSpd;
    float maxWidth;
    float currentAcc;
    float stopDuration;

    void Start()
    {
        self = GetComponent<RectTransform>();
        maxWidth = transform.parent.GetComponent<RectTransform>().sizeDelta.x;
    }

    public float GetPos()
    {
        return self.sizeDelta.x - maxWidth / 2;
    }

    public void Stop(float duration)
    {
        stopDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopDuration > 0)
        {
            stopDuration -= Time.deltaTime;
            return;
        }
        if (Input.GetMouseButton(0) && Input.GetAxis("Mouse X") > 0)
        {
            currentSpd = GetRand(expandSpeedRange);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            currentAcc = -expandLerpSpd;
        }

        currentSpd += currentAcc * Time.deltaTime;
        if (currentSpd <= shrinkSpeed)
        {
            currentAcc = 0;
        }

        float newWidth = self.sizeDelta.x + currentSpd * Time.deltaTime;
        newWidth = Mathf.Clamp(newWidth, 0, maxWidth);
        self.sizeDelta = new Vector2(newWidth, self.sizeDelta.y);
    }

    float GetRand(Vector2 range)
    {
        return UnityEngine.Random.Range(range.x, range.y);
    }
}

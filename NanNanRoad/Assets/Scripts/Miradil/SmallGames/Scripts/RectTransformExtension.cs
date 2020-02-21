using UnityEngine;
using UnityEditor;

public static class RectTransformExtension
{
    public static bool Contains(this RectTransform rectTransform, float xPos)
    {
        float l = rectTransform.rect.xMin + rectTransform.anchoredPosition.x;
        float r = rectTransform.rect.xMax + rectTransform.anchoredPosition.x;

        return l <= xPos && xPos <= r;
    }
}
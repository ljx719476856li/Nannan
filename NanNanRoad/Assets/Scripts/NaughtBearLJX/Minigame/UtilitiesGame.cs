using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitiesGame
{
    private static UtilitiesGame _instance;
    public static UtilitiesGame Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UtilitiesGame();
            return _instance;
        }
    }

    public float thresholdValue;


    /// <summary>
    /// 返回随机值
    /// </summary>
    /// <returns></returns>
    public float GetRandomNum()
    {
        return Random.Range(0.0f, 1.0f);
    }

    public void RefreshPos(ref Vector3 vec)
    {
        float x = vec.x + Random.Range(-3.2f, 3.2f);
        if(x == vec.x)
            x = vec.x + Random.Range(-3.2f, 3.2f);
        if (x > 3.2f)
            x = 0.0f;
        if (x < -3.2f)
            x = 0.0f;

        vec.Set(x, vec.y, vec.z);
    }
    public void RefreshPs(ref Vector3 vec, Vector2 range)
    {
        float x = vec.x + Random.Range(range.x, range.y);
        if (x == vec.x)
            x = vec.x + Random.Range(range.x, range.y);
        if (x > range.y)
            x = 0.0f;
        if (x < range.x)
            x = 0.0f;

        vec.Set(x, vec.y, vec.z);
    }
    public void RefreshPos3(ref Vector3 vec)
    {
        float x = vec.x + Random.Range(-9.6f, 9.6f);
        if (x == vec.x)
            x = vec.x + Random.Range(-9.6f, 9.6f);
        if (x > 9.6f)
            x = 0.0f;
        if (x < -9.6f)
            x = 0.0f;

        vec.Set(x, vec.y, vec.z);
    }

    public Vector3 RefreshPosLight(Vector3 vec)
    {
        float x = vec.x + Random.Range(-1f, 0.0f);
        if (x == vec.x)
            x = vec.x + Random.Range(-1f, 0.0f);
        if (x < -17.6f)
            x = -17.6f;

        vec.Set(x, vec.y, vec.z);
        return vec;
    }

    public void RefreshPos2(ref Vector3 vec)
    {
        vec = Vector3.zero;
    }
    public void RefreshPos4(ref Vector3 vec)
    {
        float x = vec.x + Random.Range(2f, 0.0f);
        if (x == vec.x)
            x = vec.x + Random.Range(2f, 0.0f);
        if (x > 17.6f)
            x = 17.6f;

        vec.Set(x, vec.y, vec.z);
    }


}

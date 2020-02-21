using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public GameObject Tree;
    public GameObject Stone;
    public GameObject Road;
    public Camera camera;

    public void SetCamera(bool flag)
    {
        camera.gameObject.SetActive(flag);
    }

    public void OnTreeEnter()
    {
        if(Tree != null)
        {
            SetCamera(true);
            Tree.SetActive(true);
            Debug.Log("OnTree Enter");
        }
    }
    public void OnTreeExit()
    {
        if (Tree != null)
        {
            SetCamera(false);
            Tree.SetActive(false);
            Debug.Log("OnTree Exit");
        }
    }

    public void OnStoneEnter()
    {
        SetCamera(true);
        Stone.SetActive(true);
        Debug.Log("OnStone Enter");
    }
    public void OnStoneExit()
    {
        SetCamera(false);
        Stone.SetActive(false);
        Debug.Log("OnStone Exit");
    }

    public void OnRoadEnter()
    {
        SetCamera(true);
        Road.SetActive(true);
        Debug.Log("OnRoad Enter");
    }
    public void OnRoadExit()
    {
        SetCamera(false);
        Road.SetActive(false);
        Debug.Log("OnRoad Exit");
    }
}

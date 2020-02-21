using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmallGameStarter : MonoBehaviour
{
    public static SmallGameStarter instance;
    public enum SmallGameType : int
    {
        TREE_CHOP,
        PUSH_OBJECT,
        FILL_ROAD
    }
    public GameObject[] prefabs;

    private void Start()
    {
        instance = this;
    }

    public static void StartGameStatic(SmallGameType type)
    {
        instance.StartGame((int)type);
    }

    public void StartGame(int type)
    {
        var game = Instantiate(prefabs[type]);
        game.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }
}

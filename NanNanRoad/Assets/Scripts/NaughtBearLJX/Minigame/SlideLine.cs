using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLine : MonoBehaviour
{
    public Camera cam;
    public GameObject go;
    public GameObject Tree;
    //public Vector3 startPos;
    public Vector2 threshold;
    public Vector2 sucessRange;
    public Vector3 endPos;
    private Vector3 pos;

    private void Start()
    {
        Debug.Log(transform.position);
        isMoved = true;
        UtilitiesGame.Instance.RefreshPos(ref endPos);

        tree = new Tree();
        stone = new Stone();
    }
    float timePrecentage = 0.0f;
    bool isMoved;

    private void Update()
    {
        if(isMoved == true)
        {
            if (timePrecentage < 1.0f)
            {
                timePrecentage += Time.deltaTime / 0.2f;
                transform.position = Vector3.Lerp(transform.position, endPos, timePrecentage);
            }
            else
            {
                timePrecentage = 0.0f;
                UtilitiesGame.Instance.RefreshPs(ref endPos, threshold);
            }
        }
    }

    Tree tree;
    public void DisableTree()
    {
        if (sucessRange.x <= transform.position.x && transform.position.x <= sucessRange.y)
        {
            if (tree.HP > 0)
            {
                //tree.HP -= (int)Mathf.Abs(transform.position.x);
                tree.HP -= 1;
                Debug.Log("HP:" + tree.HP);
                if (tree.HP <= 0)
                {
                    isMoved = false;

                    this.enabled = false;
                    Debug.Log("disable");
                    go.SetActive(false);
                    Tree.SetActive(false);
                    cam.gameObject.SetActive(false);
                    //Destroy(go);
                }
            }
        }

    }

    Stone stone;
    public void DisableStone()
    {
        if(sucessRange.x <= transform.position.x && transform.position.x <= sucessRange.y)
        {
            if (stone.HP > 0)
            {
                //stone.HP -= (int)Mathf.Abs(transform.position.x);
                stone.HP -= 1;
                Debug.Log("HP:" + stone.HP);
                if (stone.HP <= 0)
                {
                    isMoved = false;
                    this.enabled = false;
                    Debug.Log("disable");
                    go.SetActive(false);
                    Tree.SetActive(false);
                    cam.gameObject.SetActive(false);
                    //Destroy(go);
                }
            }
        }

    }

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(10.0f);
            Debug.Log(string.Format("Timer2 is up !!! time=${0}", Time.time));
        }
    }

    public void Test()
    {
        //isContron = true;
        if (sucessRange.x <= transform.position.x && transform.position.x <= sucessRange.y)
        {
            if (stone.HP > 0)
            {
                StartCoroutine(Timer());
                //stone.HP -= (int)Mathf.Abs(transform.position.x);
                stone.HP -= 1;
                Debug.Log("HP:" + stone.HP);
                if (stone.HP <= 0)
                {
                    isMoved = false;
                    //isContron = false;
                    Debug.Log("disable");
                    
                    //Destroy(go);
                }
            }
        }
    }
}

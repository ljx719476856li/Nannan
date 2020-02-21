using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public UnityEvent OnSceneEnter, OnSceneExit;
    //public string NextScene;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
        OnSceneEnter.Invoke();
    }
    void OnSceneUnloaded(Scene scene)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
        OnSceneExit.Invoke();
    }
    private void OnValidate()
    {
        gameObject.name = "SceneMgr";
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "SceneMgr";
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(string sceneName)
    {
        OnSceneExit.Invoke();
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}

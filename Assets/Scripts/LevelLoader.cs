using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{




    public static LevelLoader Instance;

    public Animator transition;

    public float transitionTime = 1f;

    IEnumerator Load(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    
        SceneManager.LoadScene(levelIndex);
    
    
    }

    IEnumerator Load(string levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);


    }



    // Start is called before the first frame update
    void Start()
    {
        Instance = this;


    }


    public bool LoadLevel(string LevelName)
    {
        try
        {
       
           StartCoroutine(Load(LevelName));

            return true;
        }catch(Exception e)
        {
            Debug.LogException(e);
            return false;
        }
    }

    public bool LoadLevel(int LevelIndex)
    {
        try
        {
            StartCoroutine(Load(LevelIndex));

            return true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public static StartGame instance;

    public string Name;

    public int highestscore;

    public float MouseSensitivity = 100f;



    public void SetName(string name)
    {
        Name = name;
    }

    public void StartGames()
    {
        if (Name == "" || Name == null)
        {
            return;
        }


        Destroy(Gamemanager.instance.gameObject);

        SceneManager.LoadScene(Gamemanager.instance.Tutorial);
    }



    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {

            Destroy(gameObject);
            BombRushUIManager.instance.Username.text = StartGame.instance.Name;
            Debug.Log("Called");
            BombRushUIManager.instance.Username.ForceLabelUpdate();
            BombRushUIManager.instance.MaxScoreboard.text = StartGame.instance.highestscore.ToString();
       
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

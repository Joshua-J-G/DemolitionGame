using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public static StartGame instance;

    public string Name;

    //all the player settings and high scores
    public int highestscore;
    public int highestscoreTactics;

    public float MouseSensitivity = 100f;

    public float FOV = 60f;

    public float Sound = 100f;

    //sets the players name
    public void SetName(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Start Bombrush Gamemonde
    /// </summary>
    public void StartGames()
    {
        //Checks if the players name is null and if it is stop the code
        if (Name == "" || Name == null)
        {
            Debug.Log("setName");
            return;
        }
        //Loads the tutorial Level Which is Managed by the Gamemanager there is 2 options if you want something like this (add to my code to add tactics or create your own version of Gamemanger for bombrush) i'll let you choose
        SceneManager.LoadScene(Gamemanager.instance.Tutorial);
        //Destory the old gamemanager (this is done to stop the pervious gamemanager score,time,weapons ect from transfering over) it just resets the game competly a new version of the game manager is created apon loading the new scene 
        Destroy(Gamemanager.instance.gameObject);

       
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
            TacticsUIMenu.instance.Username.text = StartGame.instance.Name;
            Debug.Log("Called");
            BombRushUIManager.instance.Username.ForceLabelUpdate();
            TacticsUIMenu.instance.Username.ForceLabelUpdate();
            BombRushUIManager.instance.MaxScoreboard.text = StartGame.instance.highestscore.ToString();
            TacticsUIMenu.instance.MaxScoreboard.text = StartGame.instance.highestscoreTactics.ToString();

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

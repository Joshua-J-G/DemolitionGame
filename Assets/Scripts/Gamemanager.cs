using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public int AmountOfItemsInSystem;
    public int DestroyedItemsInSystem;

    public bool gameEnd = true;

    public bool CanPlayerMove = false;

    public float time = 10f;


    public int levels = 3;
    public int currentlevel = 0;

    private void Awake()
    {
 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance.AmountOfItemsInSystem = 0;
            instance.DestroyedItemsInSystem = 0;
            Destroy(gameObject);
        }
    }

    public int Points;
    public int TotalPoints;



    public void RoundStarted()
    {
        gameEnd = false;
        CanPlayerMove = false;
        Points = 0;
    }

    public void GameEnd()
    {
        SceneManager.LoadScene(4);

        uihandle.instance.inputName.text = StartGame.instance.Name;

        if (StartGame.instance.highestscore < TotalPoints)
        {
            StartGame.instance.highestscore = TotalPoints;
        }

        uihandle.instance.score.text = StartGame.instance.highestscore.ToString();
  
        Leaderboard.Instance.SetLeaderboardEntry(StartGame.instance.Name, TotalPoints);

    }

    public void RoundEnded(int PercentageDestroyed,int timeRemaning)
    {
        if(gameEnd)
        {
            return;
        }

        gameEnd = true;

        Points = DestroyedItemsInSystem * 10;

        Points += Mathf.RoundToInt(Points * (timeRemaning / 2));

        if(PercentageDestroyed == 100)
        {
           Points = Points *2;
        }

        TotalPoints += Points;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

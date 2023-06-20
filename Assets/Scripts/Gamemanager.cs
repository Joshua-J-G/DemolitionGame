using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public enum Levels
{
    Small,
    Medium,
    Large
}

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public int AmountOfItemsInSystem;
    public int DestroyedItemsInSystem;

    public bool gameEnd = true;

    public bool CanPlayerMove = false;

    public float time = 10f;

    public bool IsTutorialMode = false;


    public GameObject Dynamite;

    public Levels LevelSize;

    public string Tutorial;

    public string MainMenu;
    public string Shop;

    public string CurrentLevel;

    public List<string> SmallLevels = new List<string>();
    public List<string> MediumLevels = new List<string>();
    public List<string> LargeLevels = new List<string>();
    public List<string> TacticLevels = new List<string>();

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
        SceneManager.LoadScene(MainMenu);

        BombRushUIManager.instance.Username.text = StartGame.instance.Name;

        if (StartGame.instance.highestscore < TotalPoints)
        {
            StartGame.instance.highestscore = TotalPoints;
        }

  
  
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

    public GameObject PrefabC4;

    void Start()
    {
        //Set the cost of Weapon Values
        WeaponValues.C4 = new Weapon();
        WeaponValues.C4.LevelType = Levels.Small;
        WeaponValues.C4.Cost = 400;
        WeaponValues.C4.WeaponName = "C4";
        WeaponValues.C4.Prefab = PrefabC4;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

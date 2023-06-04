using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public int AmountOfItemsInSystem;
    public int DestroyedItemsInSystem;

    public bool gameEnd = true;

    public bool CanPlayerMove = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
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

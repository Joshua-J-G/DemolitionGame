using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using Unity.Mathematics;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class FirstCountdown : MonoBehaviour
{
    public TMP_Text CountdownBeforereal;

    public TMP_Text CoundownBomb;

    public GameObject TimeHandel1;


    public TMP_Text Percentage;


    public TMP_Text TotalAmomnt;
    public TMP_Text TotalDestroyed;
    public TMP_Text PercentageDestroyed;
    public TMP_Text TimeLeft;
    public TMP_Text Points;


    float time = 2.5f;

    float TotalTime = 10f;

    bool stoptimer = false;

    public GameObject ENDPOINT;

    float nextleveltime = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountdownBeforereal.text = (Mathf.Round(time)+1).ToString();
        if(time <= 0)
        {
            TimeHandel1.SetActive(false);

            if (!stoptimer)
            {
                TotalTime -= Time.deltaTime;
                CoundownBomb.text = (Mathf.Round(TotalTime)).ToString();
                
            }

            if(Gamemanager.instance.CanPlayerMove == false)
            {
                Gamemanager.instance.CanPlayerMove = true;
            }

        }
        time -= Time.deltaTime;


        if(((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f == 100)
        {
            stoptimer = true;
            Gamemanager.instance.RoundEnded((int)((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100, (int)Mathf.Round(TotalTime));
            ENDPOINT.SetActive(true);
            nextleveltime -= Time.deltaTime;
            if (nextleveltime <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if(TotalTime <= 0)
        {
            stoptimer = true;
            Gamemanager.instance.RoundEnded((int)((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100, (int)Mathf.Round(TotalTime));
            ENDPOINT.SetActive(true);
            nextleveltime -= Time.deltaTime;
            if(nextleveltime <= 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        Percentage.text = (((float)Gamemanager.instance.DestroyedItemsInSystem/(float)Gamemanager.instance.AmountOfItemsInSystem) * 100f).ToString() + "%";




        TotalAmomnt.text = Gamemanager.instance.AmountOfItemsInSystem.ToString();
        TotalDestroyed.text = Gamemanager.instance.DestroyedItemsInSystem.ToString();
        PercentageDestroyed.text = ((int)((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100).ToString() + "%";
        TimeLeft.text = Mathf.RoundToInt(TotalTime).ToString();
        Points.text = Gamemanager.instance.TotalPoints.ToString();
    }
}

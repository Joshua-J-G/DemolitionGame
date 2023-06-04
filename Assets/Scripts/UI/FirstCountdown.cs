using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using Unity.Mathematics;

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
        TotalTime = Gamemanager.instance.time;
        CoundownBomb.text = TotalTime.ToString();
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
            PercentageDestroyed.text = (((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f).ToString() + "%";
            Gamemanager.instance.CanPlayerMove = false;
            stoptimer = true;
            Gamemanager.instance.RoundEnded((int)((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100, (int)Mathf.Round(TotalTime));
            ENDPOINT.SetActive(true);
            nextleveltime -= Time.deltaTime;
            if (nextleveltime <= 0)
            {
                Gamemanager.instance.currentlevel++;
                if (Gamemanager.instance.currentlevel == Gamemanager.instance.levels)
                {
                    Gamemanager.instance.currentlevel = 1;
                    Gamemanager.instance.time--;
                    SceneManager.LoadScene(Gamemanager.instance.currentlevel);
                }
                else
                {

                    SceneManager.LoadScene(Gamemanager.instance.currentlevel);
                }
            }
        }

        if(TotalTime <= 0)
        {
            PercentageDestroyed.text = (((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f).ToString() + "%";
            Gamemanager.instance.CanPlayerMove = false;

            stoptimer = true;
            Gamemanager.instance.RoundEnded((int)((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100, (int)Mathf.Round(TotalTime));
            ENDPOINT.SetActive(true);
            nextleveltime -= Time.deltaTime;

          

            if (nextleveltime <= 0) {

                if (((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f <= 70)
                {
                    Gamemanager.instance.GameEnd();
              
                }else
                {
                    Gamemanager.instance.currentlevel++;
                    if (Gamemanager.instance.currentlevel == Gamemanager.instance.levels)
                    {
                        Gamemanager.instance.currentlevel = 1;
                        Gamemanager.instance.time--;
                        SceneManager.LoadScene(Gamemanager.instance.currentlevel);
                    }
                    else
                    {

                        SceneManager.LoadScene(Gamemanager.instance.currentlevel);
                    }

                }



            }
        }

        Percentage.text = (((float)Gamemanager.instance.DestroyedItemsInSystem/(float)Gamemanager.instance.AmountOfItemsInSystem) * 100f).ToString() + "%";




        TotalAmomnt.text = Gamemanager.instance.AmountOfItemsInSystem.ToString();
        TotalDestroyed.text = Gamemanager.instance.DestroyedItemsInSystem.ToString();
        
        TimeLeft.text = Mathf.RoundToInt(TotalTime).ToString();
        Points.text = Gamemanager.instance.TotalPoints.ToString();
    }
}

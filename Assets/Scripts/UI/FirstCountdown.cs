using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using Unity.Mathematics;

using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

public class FirstCountdown : MonoBehaviour
{
    public TMP_Text CountdownBeforereal;
    public TMP_Text CountdownBeforereal2;

    public TMP_Text CoundownBomb;

    public GameObject TimeHandel1;
    public GameObject TimeHandel2;

    public TMP_Text Percentage;


    public TMP_Text PercentageDestroyed;
    public TMP_Text TimeLeft;
    public TMP_Text Points;


    float time = 2.5f;

    float TotalTime = 10f;

    bool stoptimer = false;

    public GameObject ENDPOINT;

    public GameObject SetPoint,Setpoint2;

    public GameObject TopBar,BottomBar;

    float nextleveltime = 3f;

    public TMP_Text Grade;

    public Image SuccessImage;
    public Sprite sus, fail;

    // Start is called before the first frame update
    void Start()
    {
        TotalTime = Gamemanager.instance.time;
        CoundownBomb.text = TotalTime.ToString();

        Gamemanager.instance.CurrentLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {






        CountdownBeforereal.text = (Mathf.Round(time)+1).ToString();
        CountdownBeforereal2.text = (Mathf.Round(time)+1).ToString();
        if(time <= 0)
        {
            TimeHandel1.SetActive(false);
            TimeHandel2.SetActive(false);
            if (!stoptimer && !Gamemanager.instance.IsTutorialMode)
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
            PlayAnimation();
            
            PercentageDestroyed.text = Mathf.RoundToInt((((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f)).ToString() + "%";
            Gamemanager.instance.CanPlayerMove = false;
            stoptimer = true;
            GradeCaculator();
            Gamemanager.instance.RoundEnded((int)((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100, (int)Mathf.Round(TotalTime));
            ENDPOINT.SetActive(true);
            nextleveltime -= Time.deltaTime;
           
            if (nextleveltime <= 0)
            {
                switch (Gamemanager.instance.LevelSize)
                {
                    case Levels.Small:

                        if (Gamemanager.instance.CurrentLevel == Gamemanager.instance.SmallLevels.Last())
                        {
                           
                            LevelLoader.Instance.LoadLevel(Gamemanager.instance.Shop);
                        }
                        else
                        {
                            
                            LevelLoader.Instance.LoadLevel(Gamemanager.instance.SmallLevels[Gamemanager.instance.SmallLevels.IndexOf(Gamemanager.instance.CurrentLevel) + 1]);
                        }



                        break;
                    case Levels.Medium:
                        break;
                    case Levels.Large:
                        break;

                }
            }
        }

        if(TotalTime <= 0)
        {
            PlayAnimation();
            PercentageDestroyed.text = Mathf.RoundToInt((((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f)).ToString() + "%";
            Gamemanager.instance.CanPlayerMove = false;

            stoptimer = true;
            GradeCaculator();
            Gamemanager.instance.RoundEnded((int)((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100, (int)Mathf.Round(TotalTime));
            ENDPOINT.SetActive(true);
            nextleveltime -= Time.deltaTime;
          



            if (nextleveltime <= 0) {

                if (((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f <= 70)
                {
                    Gamemanager.instance.GameEnd();
              
                }else
                {
                    switch(Gamemanager.instance.LevelSize)
                    {
                        case Levels.Small:

                        if(Gamemanager.instance.CurrentLevel == Gamemanager.instance.SmallLevels.Last())
                        {
                                LevelLoader.Instance.LoadLevel(Gamemanager.instance.Shop);
                            }
                            else
                        {


                                LevelLoader.Instance.LoadLevel(Gamemanager.instance.SmallLevels[Gamemanager.instance.SmallLevels.IndexOf(Gamemanager.instance.CurrentLevel) + 1]);
                            }



                        break;
                        case Levels.Medium:
                            break;
                        case Levels.Large:
                            break;

                    }
                    
                }



            }
        }

        Percentage.text = Mathf.RoundToInt((((float)Gamemanager.instance.DestroyedItemsInSystem/(float)Gamemanager.instance.AmountOfItemsInSystem) * 100f)).ToString() + "%";





        
        TimeLeft.text = Mathf.RoundToInt(TotalTime).ToString();
        Points.text = Gamemanager.instance.TotalPoints.ToString();
    }

    float timesw = 0f;

    public void GradeCaculator()
    {

        if ((((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f) < 90)
        {
            //Grade C
            Grade.text = "C";
            SuccessImage.sprite = sus;
        }

        if ((((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f) < 70)
        {
            //Grade D
            Grade.text = "D";
            SuccessImage.sprite = fail;
        }

        if ((((float)Gamemanager.instance.DestroyedItemsInSystem / (float)Gamemanager.instance.AmountOfItemsInSystem) * 100f) == 0)
        {
            //Grade E
            Grade.text = "E";
            SuccessImage.sprite = fail;
        }

      


        if (Mathf.RoundToInt(TotalTime) >= 0 && PercentageDestroyed.text == "100%")
        {
            //Grade B
            Grade.text = "B";
            
            SuccessImage.sprite = sus;
        }

        if (Mathf.RoundToInt(TotalTime) >= 3 && PercentageDestroyed.text == "100%")
        {
            //Grade A
            Grade.text = "A";
            
            SuccessImage.sprite = sus;
        }

        if (Mathf.RoundToInt(TotalTime) >= 6 && PercentageDestroyed.text == "100%")
        {
            //Grade S
            Grade.text = "S";
            
            SuccessImage.sprite = sus;
        }

        if (Mathf.RoundToInt(TotalTime) >= 9 && PercentageDestroyed.text == "100%")
        {
            //Grade S+
            Grade.text = "S+";
            
            SuccessImage.sprite = sus;
        }


    }

    public void PlayAnimation()
    {
        timesw += Time.deltaTime;
        timesw = Mathf.Clamp(timesw,0,2.5f);

        float ratio = timesw / 2;

        TopBar.transform.position = Vector3.Lerp(TopBar.transform.position, SetPoint.transform.position, ratio);
        BottomBar.transform.position = Vector3.Lerp(BottomBar.transform.position, Setpoint2.transform.position, ratio);
    }
}

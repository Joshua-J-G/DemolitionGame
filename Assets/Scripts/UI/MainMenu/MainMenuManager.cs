using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScreenSpace
{
    Mainmenu,
    BombRush,
    Tactick,
    Settings,
    Quit
}

public class MainMenuManager : MonoBehaviour
{
    public ScreenSpace CurrentSpace;


    public GameObject Offshoot;
    public GameObject Offshoot2;
    public GameObject Center;


    [Header("Debug Menu")]
    public KeyCode[] cheats = {KeyCode.UpArrow,KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.DownArrow,KeyCode.LeftArrow,KeyCode.RightArrow,KeyCode.LeftArrow,KeyCode.RightArrow,KeyCode.A,KeyCode.B,KeyCode.KeypadEnter};
    int index = 0;

    [Header("BombRush")]
    public AnimationCurve BombRushCurve;
    public GameObject BombRushScreen;


    public Vector3 BRPositionOffset;

    public Vector3 BombRushTitlePos;
    

    bool inbombrushScreen = false;
    bool bomScrenOpen = false;

    float timeBR=0;
    float LerpTimeBR = 1f;

    public float SpeedOfBR = 1f;

    [Header("Tactics")]
    public AnimationCurve TacticsCurve;
    public GameObject TacticsScreen;


    public Vector3 TPositionOffset;

    public Vector3 TTitlePos;


    bool inTacticsScreen = false;
    bool TacticsOpen = false;

    float timeT = 0;
    float LerpTimeT = 1f;

    public float SpeedOfT = 1f;


    [Header("Settings")]
    public ParticleSystem Dust;
    public AnimationCurve SettingsCurve;
    public GameObject SettingsScreen;


    public Vector3 SPositionOffset;

    public Vector3 SettingsTitlePos;


    bool inSettingsScreen = false;
    bool setingsScreenOpen = false;

    float timeSE = 0;
    float LerpTimeSE = 1f;

    public float SpeedOfSE = 1f;




    public void Quit()
    {
        Application.Quit(0);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public void TransitionToBombRush()
    {
        float Lerpration = timeBR / LerpTimeBR;
        
        BombRushScreen.transform.position = Vector3.Lerp(BombRushTitlePos, Offshoot.transform.position, BombRushCurve.Evaluate(Lerpration));
        if(Lerpration == 1)
        {
            BombRushScreen.transform.position = Center.transform.position;
        }
 
    }



    public void TransitionToTactics()
    {
        float Lerpration = timeT / LerpTimeT;

        TacticsScreen.transform.position = Vector3.Lerp(BombRushTitlePos, Offshoot.transform.position, BombRushCurve.Evaluate(Lerpration));
        if (Lerpration == 1)
        {
            TacticsScreen.transform.position = Center.transform.position;
        }

    }



    bool particalsLaunched = false;
    public void TransitionToSettings()
    {
      
        float Lerpration = timeSE / LerpTimeSE;

        SettingsScreen.transform.position = Vector3.Lerp(SettingsTitlePos, Offshoot2.transform.position, BombRushCurve.Evaluate(Lerpration));
        if(timeSE > 0.1f && !particalsLaunched)
        {
            particalsLaunched = true;
            Dust.gameObject.SetActive(true);
            Dust.Play();
        }
        if (Lerpration == 1)
        {
            SettingsScreen.transform.position = Center.transform.position;
        }

    }

    public void ResetToBombRush()
    {
        float Lerpration = timeBR / LerpTimeBR;

        BombRushScreen.transform.position = Vector3.Lerp(BombRushScreen.transform.position, BombRushTitlePos, Lerpration);
        if (Lerpration == 1)
        {
            bomScrenOpen = false;
            BombRushScreen.transform.position = BombRushTitlePos;
        }
    }


    public void ResetToTactics()
    {
        float Lerpration = timeT / LerpTimeT;

        TacticsScreen.transform.position = Vector3.Lerp(TacticsScreen.transform.position, BombRushTitlePos, Lerpration);
        if (Lerpration == 1)
        {
            TacticsOpen = false;
            TacticsScreen.transform.position = BombRushTitlePos;
        }
    }

    public void ResetToSettings()
    {

        if (Dust.isPlaying)
        {
           
            Dust.Stop();
        }
        particalsLaunched = false;
        float Lerpration = timeSE / LerpTimeSE;

        SettingsScreen.transform.position = Vector3.Lerp(SettingsScreen.transform.position, SettingsTitlePos, Lerpration);
        if (Lerpration == 1)
        {
            setingsScreenOpen = false;
            SettingsScreen.transform.position = SettingsTitlePos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BombRushTitlePos = BombRushScreen.transform.position;
        SettingsTitlePos = SettingsScreen.transform.position;
        index = 0;
    }

    public void GoBackToMainMenu()
    {
        if(inbombrushScreen)
        {
            inbombrushScreen = false;
            timeBR = 0;
        }

        if (inSettingsScreen)
        {
            inSettingsScreen = false;
            timeSE = 0;
        }


        if (inTacticsScreen)
        {
            inTacticsScreen = false;
            timeT = 0;
        }
    }

    public void OpenBombScreen()
    {
        inbombrushScreen=true;
        bomScrenOpen = true;
        Leaderboard.Instance.GetLeaderBoard();
        timeBR = 0;
    }

    public void OpenTacticsScreen()
    {
        inTacticsScreen = true;
        TacticsOpen = true;
        Leaderboard.Instance.GetLeaderBoard();
        timeT = 0;
    }

    public void OpenSettingScreen()
    {
        inSettingsScreen = true;
        setingsScreenOpen = true;
        timeSE = 0;
    }

    public GameObject debugmenu;
    bool cheatsmenuopen = false;

    bool hasUpdatedScreen = false;

    // Update is called once per frame
    void Update()
    {

        

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheats[index]) && !cheatsmenuopen)
            {
                index++;
            }else
            {
                index = 0;
            }
        }

        if(index == cheats.Length)
        {
            cheatsmenuopen = true;
            debugmenu.SetActive(true);

        }


        if (inbombrushScreen)
        {
            TransitionToBombRush();
            timeBR += Time.deltaTime * SpeedOfBR;
            timeBR = Mathf.Clamp(timeBR, 0, LerpTimeBR);
        }
        else if (bomScrenOpen)
        {
            ResetToBombRush();
            timeBR += Time.deltaTime * SpeedOfBR;
            timeBR = Mathf.Clamp(timeBR, 0, LerpTimeBR);
        }




        if (inTacticsScreen)
        {
            TransitionToTactics();
            timeT += Time.deltaTime * SpeedOfT;
            timeT = Mathf.Clamp(timeT, 0, LerpTimeT);
        }
        else if (TacticsOpen)
        {
            ResetToTactics();
            timeT += Time.deltaTime * SpeedOfT;
            timeT = Mathf.Clamp(timeT, 0, LerpTimeT);
        }


        if (inSettingsScreen)
        {
            TransitionToSettings();
            timeSE += Time.deltaTime * SpeedOfSE;
            timeSE = Mathf.Clamp(timeSE, 0, LerpTimeSE);
        }
        else if (setingsScreenOpen)
        {
            ResetToSettings();
            timeSE += Time.deltaTime * SpeedOfSE;
            timeSE = Mathf.Clamp(timeSE, 0, LerpTimeSE);
        }

    }
}

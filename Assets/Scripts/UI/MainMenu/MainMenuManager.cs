using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void OpenBombScreen()
    {
        inbombrushScreen=true;
        bomScrenOpen = true;
        Leaderboard.Instance.GetLeaderBoard();
        timeBR = 0;
    }

    public void OpenSettingScreen()
    {
        inSettingsScreen = true;
        setingsScreenOpen = true;
        timeSE = 0;
    }

    // Update is called once per frame
    void Update()
    {


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

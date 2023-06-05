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


    public AnimationCurve BombRushCurve;
    public GameObject BombRushScreen;


    public Vector3 PositionOffset;

    public Vector3 BombRushTitlePos;
    

    bool inbombrushScreen = false;
    bool bomScrenOpen = false;

    public GameObject Offshoot;
    public GameObject Center;
    float timeBR=0;
    float LerpTimeBR = 1f;

    public float SpeedOfBR = 1f;


    

    public void TransitionToBombRush()
    {
        float Lerpration = timeBR / LerpTimeBR;
        
        BombRushScreen.transform.position = Vector3.Lerp(BombRushTitlePos, Offshoot.transform.position, BombRushCurve.Evaluate(Lerpration));
        if(Lerpration == 1)
        {
            BombRushScreen.transform.position = Center.transform.position;
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



    // Start is called before the first frame update
    void Start()
    {
        BombRushTitlePos = BombRushScreen.transform.position;
    }

    public void GoBackToMainMenu()
    {
        inbombrushScreen = false;
        timeBR = 0;
    }

    public void OpenBombScreen()
    {
        inbombrushScreen=true;
        bomScrenOpen = true;
        Leaderboard.Instance.GetLeaderBoard();
        timeBR = 0;
    }

    // Update is called once per frame
    void Update()
    {
    

        if (inbombrushScreen)
        {
            TransitionToBombRush();
            timeBR += Time.deltaTime * SpeedOfBR;
            timeBR = Mathf.Clamp(timeBR, 0, LerpTimeBR);
        }else if(bomScrenOpen)
        {
            ResetToBombRush();
            timeBR += Time.deltaTime * SpeedOfBR;
            timeBR = Mathf.Clamp(timeBR, 0, LerpTimeBR);
        }
    }
}

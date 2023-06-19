using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombRushUIManager : MonoBehaviour
{
    public static BombRushUIManager instance;

    [SerializeField]
    private TMP_Text CharCount;

    [SerializeField]
    public TMP_InputField Username;

    


    [Header("Scoreboard Information")]
    [SerializeField]
    private Image ScoreboardSwitch;

    [SerializeField]
    private Sprite SOnline, SLocal;

    [SerializeField]
    private TMP_Text SetTheScoreBoards;

    public string PlayerUserName = "";



    [Header("Scoreboard Information")]
    [SerializeField]
    private Image PlaySwitch;

    [SerializeField]
    private Sprite NeedtoEnterAName, CanPlay;


    public TMP_Text MaxScoreboard;

    public void Awake()
    {
        instance = this;
    }

    public void UpdateCharCount(string text)
    {
        PlayerUserName = text;
        StartGame.instance.SetName(PlayerUserName);
        CharCount.text = (Username.characterLimit - PlayerUserName.Length).ToString();

        if(PlayerUserName == null || PlayerUserName == "")
        {
            PlaySwitch.sprite = NeedtoEnterAName;
        }else
        {
            PlaySwitch.sprite = CanPlay;
        }
    }


    public void SwichLeadboards()
    {


        Leaderboard.Instance.SwapLeaderboards();
        if(Leaderboard.Instance.isOnline)
        {
            ScoreboardSwitch.sprite = SOnline;
            SetTheScoreBoards.text = "ONLINE SCOREBOARD";
        }
        else
        {
            ScoreboardSwitch.sprite = SLocal;
            SetTheScoreBoards.text = "LOCAL SCOREBOARD";
        }
    }


    public void CheckIfPlayerCanPlay()
    {

        if (PlayerUserName == null || PlayerUserName == "")
        {
            return;
        }else
        {

        }
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

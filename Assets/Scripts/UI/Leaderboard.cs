using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard Instance;

    [SerializeField]
    private List<TextMeshProUGUI> names;

    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicKey = "d31e8cfb72bf9671b6a5ed425518a85336ced6bcf191757a18893636390c307b";

    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {
            int looplength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i = 0; i < looplength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username,int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, username, score, ((msg) =>
        {
            
            GetLeaderBoard();
        }));
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetLeaderBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

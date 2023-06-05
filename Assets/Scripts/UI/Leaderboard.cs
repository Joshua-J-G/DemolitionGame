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

    public bool isOnline = true;

    private string publicKey = "d31e8cfb72bf9671b6a5ed425518a85336ced6bcf191757a18893636390c307b";

    // secret key 725b90f27c469d7c9d763702a5a947f7ac52dbf64fa5bcb620c11e13cd807c324903af0f72fc0febe60653e48b32e00a58522ca536a2c8ae155155641d59282b9522b0ee7c0e05fdcc8edd9c4fc7d3fcbbd10454f74b94e4774e742c8802e89779462a21182ef6da7e7008162c1e3885b44de8bc21b5beb543f02e09343c1408

    public void SwapLeaderboards()
    {
        isOnline = !isOnline;

        if (isOnline)
        {
            GetLeaderBoard();
        }
        else
        {
            foreach (TMP_Text t in names)
            {
                t.text = "";
            }

            foreach (TMP_Text t in scores)
            {
                t.text = "";
            }
        }

    }


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

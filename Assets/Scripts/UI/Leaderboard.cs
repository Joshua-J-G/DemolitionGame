using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using System.IO;
using System.Linq;

struct scoreboardsetup
{
    public string name;
    public int score;
}

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard Instance;

    [SerializeField]
    private List<TextMeshProUGUI> names;

    [SerializeField]
    private List<TextMeshProUGUI> scores;


    [SerializeField]
    private List<TextMeshProUGUI> namesT;

    [SerializeField]
    private List<TextMeshProUGUI> scoresT;

    public bool isOnline = true;
    public bool isOnlineTactics = true;

    private string publicKey = "d31e8cfb72bf9671b6a5ed425518a85336ced6bcf191757a18893636390c307b";

    // secret key 725b90f27c469d7c9d763702a5a947f7ac52dbf64fa5bcb620c11e13cd807c324903af0f72fc0febe60653e48b32e00a58522ca536a2c8ae155155641d59282b9522b0ee7c0e05fdcc8edd9c4fc7d3fcbbd10454f74b94e4774e742c8802e89779462a21182ef6da7e7008162c1e3885b44de8bc21b5beb543f02e09343c1408


    private string publicKey2 = "16f06402c616f478bfd5439ac0e1ac343285e51888d4c835cd992a365ac2868c";

    //Secret Key a3a92c093c5dc6693ace4bfbe0b7ea244c4bfa52343cb88281a93e9766fe12883d3f6e4d3583e6a13c75179a514e5ca727a3a7d92f1a46d83a530a378249429a720231e7cc0791226b4ba4d2e384381bd2a6263574a8f36311f0b3e9773ce9aa490251f1906b07560ca22933c8ba6fe93aa4b0991d591dca9972b8aa8cf28986

    public void SwapLeaderboards()
    {
        isOnline = !isOnline;

        if (isOnline)
        {
            GetLeaderBoard();
        }
        else
        {
            GetlocalLeaderboard();
        }

    }

    public void SwapLeaderboardsTactics()
    {
        isOnlineTactics = !isOnlineTactics;

        if (isOnlineTactics)
        {
            GetLeaderBoardTactics();
        }
        else
        {
            GetlocalLeaderboardTactics();
        }

    }




    int nameposTactics = 0;
    public void GetlocalLeaderboardTactics()
    {
        nameposTactics = 0;


        foreach (TMP_Text t in namesT)
        {
            t.text = "";
        }

        foreach (TMP_Text t in scoresT)
        {
            t.text = "";
        }




        List<string> lines = new List<string>();
        lines.AddRange(File.ReadAllLines(Application.persistentDataPath + "/LeaderboardTactics.txt"));

        List<scoreboardsetup> orddered = new List<scoreboardsetup>();
        List<int> holdingScore = new List<int>();
        foreach (string s in lines.ToArray())
        {
            string[] split = s.Split(",");
            scoreboardsetup w = new scoreboardsetup();

            w.name = split[0];
            w.score = int.Parse(split[1]);
            holdingScore.Add(int.Parse(split[1]));
            orddered.Add(w);
        }

        orddered = orddered.OrderBy(c => c.score).ToList();
        orddered.Reverse();
        foreach (TMP_Text t in namesT)
        {
            if (nameposTactics < orddered.ToArray().Length)
            {
                t.text = orddered[nameposTactics].name;
            }
            nameposTactics++;
        }
        nameposTactics = 0;
        foreach (TMP_Text t in scoresT)
        {
            if (nameposTactics < orddered.ToArray().Length)
            {
                t.text = orddered[nameposTactics].score.ToString();
            }
            nameposTactics++;
        }
    }


    public void GetLeaderBoardTactics()
    {
        foreach (TMP_Text t in namesT)
        {
            t.text = "";
        }

        foreach (TMP_Text t in scoresT)
        {
            t.text = "";
        }
        LeaderboardCreator.GetLeaderboard(publicKey2, ((msg) =>
        {
            int looplength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < looplength; i++)
            {
                namesT[i].text = msg[i].Username;
                scoresT[i].text = msg[i].Score.ToString();
            }
        }));
    }

    int localscoreboardTactics = 0;

    bool playeraddedtoleaderboardTactics = false;

    public void SetLeaderboardEntryTactics(string username, int score)
    {
        Debug.Log(Application.persistentDataPath + "/LeaderboardTactics.txt");
        localscoreboardTactics = 0;
        playeraddedtoleaderboardTactics = false;

        if (System.IO.File.Exists(Application.persistentDataPath + "/LeaderboardTactics.txt"))
        {
            List<string> lines = new List<string>();
            lines.AddRange(File.ReadAllLines(Application.persistentDataPath + "/LeaderboardTactics.txt"));
            foreach (string s in lines.ToArray())
            {
                string[] split = s.Split(",");
                if (split[0].ToLower() == username.ToLower())
                {
                    playeraddedtoleaderboardTactics = true;
                    if (int.Parse(split[1]) < score)
                    {
                        lines[localscoreboard] = username + "," + score;
                    }
                }
                localscoreboardTactics++;
            }


            if (!playeraddedtoleaderboardTactics)
            {
                lines.Add(username + "," + score);
            }
            File.WriteAllLines(Application.persistentDataPath + "/LeaderboardTactics.txt", lines.ToArray());
        }
        else
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/LeaderboardTactics.txt", username + "," + score);
        }

        LeaderboardCreator.UploadNewEntry(publicKey, username, score, ((msg) =>
        {

            GetLeaderBoardTactics();
        }));
    }




    int namepos = 0;
    public void GetlocalLeaderboard()
    {
        namepos = 0;


        foreach (TMP_Text t in names)
        {
            t.text = "";
        }

        foreach (TMP_Text t in scores)
        {
            t.text = "";
        }


        List<string> lines = new List<string>();
        lines.AddRange(File.ReadAllLines(Application.persistentDataPath + "/Leaderboard.txt"));

        List<scoreboardsetup> orddered = new List<scoreboardsetup>();
        List<int> holdingScore = new List<int>();
        foreach (string s in lines.ToArray())
        {
            string[] split = s.Split(",");
            scoreboardsetup w = new scoreboardsetup();
            
            w.name = split[0];
            w.score = int.Parse(split[1]);
            holdingScore.Add(int.Parse(split[1]));
            orddered.Add(w);
        }

        orddered = orddered.OrderBy(c => c.score).ToList();
        orddered.Reverse();
        foreach (TMP_Text t in names)
        {
            if (namepos < orddered.ToArray().Length)
            {
                t.text = orddered[namepos].name;
            }
            namepos++;
        }
        namepos = 0;
        foreach (TMP_Text t in scores)
        {
            if (namepos < orddered.ToArray().Length)
            {
                t.text = orddered[namepos].score.ToString();
            }
            namepos++;
        }
    }


    public void GetLeaderBoard()
    {
        foreach (TMP_Text t in names)
        {
            t.text = "";
        }

        foreach (TMP_Text t in scores)
        {
            t.text = "";
        }
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

    int localscoreboard = 0;

    bool playeraddedtoleaderboard = false;

    public void SetLeaderboardEntry(string username, int score)
    {
        Debug.Log(Application.persistentDataPath + "/Leaderboard.txt");
        localscoreboard = 0;
        playeraddedtoleaderboard = false; 

        if (System.IO.File.Exists(Application.persistentDataPath + "/Leaderboard.txt"))
        {
            List<string> lines = new List<string>();
            lines.AddRange(File.ReadAllLines(Application.persistentDataPath + "/Leaderboard.txt"));
            foreach (string s in lines.ToArray())
            {
                string[] split = s.Split(",");
                if (split[0].ToLower() == username.ToLower())
                {
                    playeraddedtoleaderboard = true;
                    if (int.Parse(split[1]) < score)
                    {
                        lines[localscoreboard] = username + "," + score;
                    }
                }
                localscoreboard++;
            }


            if(!playeraddedtoleaderboard)
            {
                lines.Add(username + "," + score);
            }
            File.WriteAllLines(Application.persistentDataPath + "/Leaderboard.txt", lines.ToArray());
        }else
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Leaderboard.txt", username + ","+ score);
        }

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
        GetLeaderBoardTactics();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

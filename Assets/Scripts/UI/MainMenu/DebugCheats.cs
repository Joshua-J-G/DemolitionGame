using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugCheats : MonoBehaviour
{
    public TMP_InputField Name, Score;
    public void ScoreTester()
    {
        Leaderboard.Instance.SetLeaderboardEntry(Name.text, int.Parse(Score.text));



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

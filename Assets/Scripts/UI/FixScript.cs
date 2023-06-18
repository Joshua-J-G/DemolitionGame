using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FixScript : MonoBehaviour
{
    public void PlayBombrush()
    {
        StartGame.instance.StartGames();
    }
    public void PlayTactics()
    {
        // Load the "Tactics" scene
        SceneManager.LoadScene("Tactics");


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

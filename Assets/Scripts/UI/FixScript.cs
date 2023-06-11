using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixScript : MonoBehaviour
{
    public void PlayBombrush()
    {
        StartGame.instance.StartGames();
    }
    public void PlayTactics()
    {
        Debug.Log("HEY YOU JUST TRIED PLAYING TACTICS enter this script for more");
        //hey this is where you load up the first level of tactics when the play button is clicked it will do anything in this function
        //as you can see above the startGame script is how i start bombrush you may want to look into that script and find out how this is loaded (may of forgoten how it works you'll be fine)
        //ill add some comments to the code
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

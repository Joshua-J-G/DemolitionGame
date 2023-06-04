using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public static StartGame instance;

    public string Name;

    public int highestscore;

    public void SetName(string name)
    {
        Name = name;
    }

    public void StartGames()
    {
        if (Name == "" || Name == null)
        {
            return;
        }


        Destroy(Gamemanager.instance.gameObject);

        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {

            Destroy(gameObject);
            uihandle.instance.inputName.text = StartGame.instance.Name;
            Debug.Log("Called");
            uihandle.instance.inputName.ForceLabelUpdate();
            uihandle.instance.score.text = StartGame.instance.highestscore.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

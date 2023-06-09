using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject Dynamite;

    public GameObject MovementTutorial;
    public GameObject JumpTutorial;
    public GameObject MouseTutorial;

    // Start is called before the first frame update
    void Start()
    {
        Gamemanager.instance.CanPlayerMove = true;
        Gamemanager.instance.IsTutorialMode = true;
    }

    bool wp=false, ap=false, sp=false, dp = false;
    bool Spacep = false;
    bool mouse1d = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            wp = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ap = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            sp = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            dp= true;
        }

        

        if(wp&&ap&&sp&&dp)
        {
            MovementTutorial.SetActive(false);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Spacep = true;
            }
            JumpTutorial.SetActive(true);
            if (Spacep)
            {
                JumpTutorial.SetActive(false);
                MouseTutorial.SetActive(true);
                Dynamite.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    mouse1d = true;
                }

                if(mouse1d)
                {
                    MouseTutorial.SetActive(false);
                    Gamemanager.instance.IsTutorialMode = false;
                }
            }
        }


    }
}

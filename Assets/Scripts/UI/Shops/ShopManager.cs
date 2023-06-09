using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Image Background;
    [Header("Right Gameobjects")]
    [SerializeField] Sprite BackgroundRight;


    [Header("Left Gameobjects")]
    [SerializeField] Sprite BackgroundLeft;

    public void ShopRight()
    {
        Background.sprite = BackgroundRight;
    }

    public void ShopLeft()
    {
        Background.sprite = BackgroundLeft;
    }


    public void ContinueClicked()
    {
        switch(Gamemanager.instance.LevelSize)
        {
            case Levels.Small:
                SceneManager.LoadScene(Gamemanager.instance.SmallLevels[0]);
                break;
            case Levels.Medium:

                break;
            case Levels.Large:

                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Gamemanager.instance.time--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

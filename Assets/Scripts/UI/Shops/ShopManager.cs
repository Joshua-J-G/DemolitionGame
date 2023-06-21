using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    /* ShopManager Script
     * ok so guys this is the script i want you guys to add to 
     * 
     * There is 3 Major Scripts that you guys need to know about 
     * 1. Player Movement
     * 2. Game Manager
     * 3. Spawn Dynamite
     * 
     * 1. The player movment script handles all things player based 
     * such as movement speed, Jump Height, Gravity and the Spawn Dynamite Script 
     * 
     * the player script has a reference to the Spawn Dynamite Script which manages the creation of all dynamite Assets in the players hand which is a gameobject
     * 
     * 2. The Game Manager is the Script that handels the current game stats such as
     * the Max Time, the amount of objects in the level, the amound of objects destroyed, percentage calculations, IS tutorial mode (DONT TOUCH THIS IS ONLY USED FOR THE FIRST LEVEL), the current level size, a list of every level (create so far noah start adding more levels in the medium and large category) and Total Points
     * this script doenst get destroyed between level and only gets destroyed when starting a new game where its replaced with a fresh copy 
     * this script is how i do the percentage caculations, save the points calculations and handle the level names 
     * 
     * 3. Spawning Dynamite is a dirt simple script that just spawns dynamite into the player hands every 0.2 seconds the big magic is in the actual dynamite prefab but it doesnt care what it spawns 
     * so if you want to add more weapons to the game what you want to do is create prefabs simular to the dynamite prefab and in this script create an array or list of gameobject and when the player buys the objects 
     * replace base dynamite with the new weapon 
     * 
     * Note: this wont work on the first throw as it is set right now to always spawn dynamite i will get on fixing this shortly 
     * 
     * 
     * 
     * 
     * 
     * 
     * Have fun coding 
     * 
     * 
     */



    //Reference to the base image
    [SerializeField] Image Background;

    [SerializeField] TMP_Text Points;

    //all buttons and gameobject that are on the right tab go here
    [Header("Right Gameobjects")]
    [SerializeField] Sprite BackgroundRight;
    [SerializeField] GameObject RightSide;

    //all buttons and gameobject that are on the left tab go here
    [Header("Left Gameobjects")]
    [SerializeField] Sprite BackgroundLeft;
    [SerializeField] GameObject LeftSide;




    [Header("Weapon Holder")]
    [SerializeField] Image buttonSprite;
    [SerializeField] TMP_Text weaponName;
    [SerializeField] TMP_Text weaponProce;





    /// <summary>
    /// Flip the image to be shop right
    /// </summary>
    public void ShopRight()
    {
        Background.sprite = BackgroundRight;
        RightSide.SetActive(true);
        LeftSide.SetActive(false);

    }

    /// <summary>
    /// Flip the image to be shop left
    /// </summary>
    public void ShopLeft()
    {
        Background.sprite = BackgroundLeft;
        RightSide.SetActive(false);
        LeftSide.SetActive(true);
    }

    public void BuyWeapon()
    {
        switch(WeaponValues.WeaponSelect)
        {
            case 0:
                if (Gamemanager.instance.TotalPoints - WeaponValues.C4.Cost > 0)
                {
                    Gamemanager.instance.TotalPoints -= WeaponValues.C4.Cost;
                    Gamemanager.instance.Dynamite = WeaponValues.C4.Prefab;
                    WeaponValues.WeaponSelect++;
                }

            break;

            case 1:
                if (Gamemanager.instance.TotalPoints - WeaponValues.ToonBomb.Cost > 0)
                {
                    Gamemanager.instance.TotalPoints -= WeaponValues.ToonBomb.Cost;
                    Gamemanager.instance.Dynamite = WeaponValues.ToonBomb.Prefab;
                    WeaponValues.WeaponSelect++;
                }

                break;

        }
    }



    /// <summary>
    /// When this Function is called it will run a switch statment to detrumin if the level should be from the small, medium or large category 
    /// </summary>
    public void ContinueClicked()
    {
        // swich statments are like fancy if Statments they just run better than a if statment and are better when you know exactly what your results are going to be
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
        //unlocks the cursor form the screen so the player can move it
        Cursor.lockState = CursorLockMode.None;

        //this removes a second from the timer
        Gamemanager.instance.time--;

       

    }

    // Update is called once per frame
    void Update()
    {
        Points.text = Gamemanager.instance.TotalPoints.ToString();
        switch (WeaponValues.WeaponSelect)
        {
            case 0:
                weaponName.text = WeaponValues.C4.WeaponName;
                weaponProce.text = WeaponValues.C4.Cost.ToString();
                break;
            case 1:
                weaponName.text = WeaponValues.ToonBomb.WeaponName;
                weaponProce.text = WeaponValues.ToonBomb.Cost.ToString();
                break;
        }
    }
}

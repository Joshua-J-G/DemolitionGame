using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    //Player Prefs

    int FOV = 60;

    int MouseSensitivity = 50;

    int SoundVolume = 100;

    public Slider FOVS, Mouse, Audio;

    public TMP_Text VFOV, VMouse, VAudio;


  
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("FOV"))
        {
            FOV = PlayerPrefs.GetInt("FOV");
            FOVS.value = FOV;
            VFOV.text = FOV.ToString();
        }

        if (PlayerPrefs.HasKey("MouseSensitivity"))
        {
            MouseSensitivity = PlayerPrefs.GetInt("MouseSensitivity");
            Mouse.value = MouseSensitivity;
            VMouse.text = MouseSensitivity.ToString();
        }

        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            SoundVolume = PlayerPrefs.GetInt("SoundVolume");
            Audio.value = SoundVolume;
            VAudio.text = SoundVolume.ToString();
        }
    }


    public void ChangeFOV()
    {
        FOV = (int)FOVS.value;
   
        VFOV.text = FOV.ToString();
    }

    public void ChangeMouse()
    {
        MouseSensitivity = (int)Mouse.value;
    
        VMouse.text = MouseSensitivity.ToString();
    }


    public void ChangeAudio()
    {
        SoundVolume = (int)Audio.value;

        VAudio.text = SoundVolume.ToString();
    }

    public void ResetToOld()
    {
        if (PlayerPrefs.HasKey("FOV"))
        {
            FOV = PlayerPrefs.GetInt("FOV");
       
        }

        if (PlayerPrefs.HasKey("MouseSensitivity"))
        {
            MouseSensitivity = PlayerPrefs.GetInt("MouseSensitivity");
     
        }

        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            SoundVolume = PlayerPrefs.GetInt("SoundVolume");

        }

        FOVS.value = FOV;
        VFOV.text = FOV.ToString();
        Audio.value = SoundVolume;
        VAudio.text = SoundVolume.ToString();
        Mouse.value = MouseSensitivity;
        VMouse.text = MouseSensitivity.ToString();
    }


    public void SaveChanges()
    {
        PlayerPrefs.SetInt("FOV", FOV);
        PlayerPrefs.SetInt("SoundVolume", SoundVolume);
        PlayerPrefs.SetInt("MouseSensitivity", MouseSensitivity);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

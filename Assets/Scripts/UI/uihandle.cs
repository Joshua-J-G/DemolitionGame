using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uihandle : MonoBehaviour
{

    public static uihandle instance;
    

    [SerializeField]
    public TMP_InputField inputName;
    public TMP_InputField inputField;

    public Slider slider;

    public TMP_Text MouiseSensitivity;

    public TMP_Text score;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        inputField.characterLimit = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

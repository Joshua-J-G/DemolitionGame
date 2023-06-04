using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputName;

    

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScoore()
    {
        submitScoreEvent.Invoke(inputName.text,int.Parse(inputName.text));
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

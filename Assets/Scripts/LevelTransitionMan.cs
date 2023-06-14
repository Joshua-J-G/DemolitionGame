using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public static class Shuffler
{
    public static void Shuffle<T>(this IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}


public class LevelTransitionMan : MonoBehaviour
{
    public List<GameObject> transitions = new List<GameObject>();


    public void Awake()
    {
        int randomnumb = UnityEngine.Random.Range(0,transitions.Count-1);

        transitions.Shuffle();
        

        transitions[randomnumb].SetActive(true); 
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

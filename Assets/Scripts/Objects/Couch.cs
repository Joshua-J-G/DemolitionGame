using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : MonoBehaviour,IExplodable
{
    public GameObject Shattered;
    Couch instance;

    bool blownupyet = false;
    public void AddToTotalPercentage()
    {
        Gamemanager.instance.AmountOfItemsInSystem++;
    }

    public void Explode()
    {
        if(blownupyet) {
            return;
        }
        blownupyet=true;
        Gamemanager.instance.DestroyedItemsInSystem++;

        GameObject gm = Instantiate(Shattered,transform);
        gm.transform.parent = null;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
   
        AddToTotalPercentage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

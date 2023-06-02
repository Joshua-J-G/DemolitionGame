using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : MonoBehaviour,IExplodable
{
    public GameObject Shattered;

    public void Explode()
    {
       
        GameObject gm = Instantiate(Shattered,transform);
        gm.transform.parent = null;
        Destroy(gameObject);
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

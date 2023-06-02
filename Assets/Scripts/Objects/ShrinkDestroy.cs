using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ShrinkDestroy : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale - Vector3.one*(Time.deltaTime/10);

        if(transform.localScale.x <= Vector3.zero.x)
        {
            Destroy(gameObject);
        }
    }
}

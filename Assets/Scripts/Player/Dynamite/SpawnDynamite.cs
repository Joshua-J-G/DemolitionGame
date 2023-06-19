using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDynamite : MonoBehaviour
{
    public static SpawnDynamite SD;

    public GameObject BaseDynamite;
    public GameObject DynamiteHand;

    private void Start()
    {
        SD = this;
        BaseDynamite = Gamemanager.instance.Dynamite;
        ReloadDynamite();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.2f);

        Instantiate(BaseDynamite, DynamiteHand.transform);
    }

    public void ReloadDynamite()
    {
        StartCoroutine(Reload());
    }
}

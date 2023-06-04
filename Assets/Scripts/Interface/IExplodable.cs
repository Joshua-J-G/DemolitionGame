using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplodable
{
    void Explode();
    void AddToTotalPercentage();


    //on add total percentage add  Gamemanager.instance.AmountOfItemsInSystem++;
    //on exploade add Gamemanager.instance.DestroyedItemsInSystem++;
}

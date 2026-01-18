using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
 
    public int maxResultNumber;

    public GameData(Data data)
    {
        maxResultNumber = data.maxResultNumber;
    }

}

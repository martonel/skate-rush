using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int maxResultNumber;

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        GameData gameData = SaveSystem.LoadData();
        maxResultNumber = gameData.maxResultNumber;

    }

    }

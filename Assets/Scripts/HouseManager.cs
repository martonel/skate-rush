using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public Transform player;

    [Header("House Lists")]
    public List<GameObject> backHouses;
    public List<GameObject> midHouses;
    public List<GameObject> frontHouses;

    [Header("Y Positions for Layers")]
    public float backY = -1f;
    public float midY = 0f;
    public float frontY = 1f;

    [Header("Spawn Settings")]
    public float spawnDistance = 20f;
    public float houseSpacing = 10f;

    private float lastBackX;
    private float lastMidX;
    private float lastFrontX;

    void Start()
    {
        lastBackX = lastMidX = lastFrontX = player.position.x;
    }

    void Update()
    {
        TrySpawnHouse(ref lastBackX, backHouses, backY);
        TrySpawnHouse(ref lastMidX, midHouses, midY);
        TrySpawnHouse(ref lastFrontX, frontHouses, frontY);
    }

    void TrySpawnHouse(ref float lastX, List<GameObject> houseList, float yPos)
    {
        if (player.position.x + spawnDistance > lastX)
        {
            GameObject prefab = houseList[Random.Range(0, houseList.Count)];
            Vector3 spawnPos = new Vector3(lastX + houseSpacing, yPos, 0f);
            GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);
            obj.transform.SetParent(transform, false);
            lastX += houseSpacing;
        }
    }
}

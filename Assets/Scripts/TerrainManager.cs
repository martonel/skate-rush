using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject[] terrainPrefabs;

    public GameObject[] specialTerrainPrefabs;
    public Transform player;
    public float spawnDistance = 60f;
    public float despawnDistance = 30f;

    private List<GameObject> activeTerrains = new List<GameObject>();
    private float lastSpawnX;
    private GameObject lastprefab;
    private float yAxis = 0;

    private int waitRocketNum = 10;
    private int waitNum = 3;

    public float spacing = 3.15f;
    void Start() 
    {
        SpawnInitialTerrains();
    }

    void Update()
    {
        if (player.position.x + spawnDistance > lastSpawnX)
        {
            SpawnTerrain();
        }

        CleanupOldTerrains();
    }

    void SpawnInitialTerrains()
    {
        for (int i = 0; i < 3; i++)
            SpawnTerrain();
    }

    void SpawnTerrain()
    {

        GameObject prefab = null;
        if (waitRocketNum == 15 || waitRocketNum == 30 || waitRocketNum == 100)
        {
            //Debug.Log("spaceShip start");
            prefab = specialTerrainPrefabs[0];

        }
        else
        {
            prefab = terrainPrefabs[Random.Range(0, terrainPrefabs.Length)];
        }
       

        if (waitNum != 0)
        {
            //Debug.Log("Spacing_ " + (yAxis - spacing));
            GameObject segment = Instantiate(terrainPrefabs[1], new Vector3(lastSpawnX, yAxis - spacing, 0), Quaternion.identity);
            activeTerrains.Add(segment);
            waitNum--;
            if(waitNum != 0)
            {
                yAxis = yAxis - 3.2f;
            }
        }
        else
        {
            if (lastprefab != null)
            {
                //Debug.Log("name: " + lastprefab.name);
                if (lastprefab.name.Contains("BG1_0") || lastprefab.name.Contains("BG2_0"))
                {
                    yAxis = yAxis - 3.2f;
                    //Debug.Log("lent végzõdõ: " + waitRocketNum);

                    GameObject segment = Instantiate(prefab, new Vector3(lastSpawnX, yAxis - spacing, 0), Quaternion.identity);
                    activeTerrains.Add(segment);
                    waitRocketNum++;
                }
                else if (lastprefab.name.Contains("BG3_0"))
                {
                    yAxis = yAxis - 14.21f;
                    //Debug.Log("lent végzõdõ: " + waitRocketNum);

                    GameObject segment = Instantiate(prefab, new Vector3(lastSpawnX, yAxis - spacing, 0), Quaternion.identity);
                    activeTerrains.Add(segment);
                    waitRocketNum++;
                }
                else if (prefab.name.Contains("Rocket"))
                {
                    yAxis = yAxis - 3.2f;
                    waitRocketNum++;
                    //Debug.Log("fent végzõdõ:1 " + waitRocketNum);
                    GameObject segment = Instantiate(prefab, new Vector3(lastSpawnX, yAxis - spacing, 0), Quaternion.identity);
                    activeTerrains.Add(segment);
                }
                else
                {
                    yAxis = yAxis - 3.2f;
                    //Debug.Log("fent végzõdõ: " + waitRocketNum);
                    GameObject segment = Instantiate(prefab, new Vector3(lastSpawnX, yAxis - spacing, 0), Quaternion.identity);
                    activeTerrains.Add(segment);
                    waitRocketNum++;
                }
            }
            else
            {
                GameObject segment = Instantiate(prefab, new Vector3(lastSpawnX, yAxis - spacing, 0), Quaternion.identity);
                activeTerrains.Add(segment);
            }
        }
        lastprefab = prefab;
        lastSpawnX += prefab.GetComponent<SpriteRenderer>().bounds.size.x - 0.01f;
    }

    void CleanupOldTerrains()
    {
        for (int i = activeTerrains.Count - 1; i >= 0; i--)
        {
            if (activeTerrains[i].transform.position.x + despawnDistance < player.position.x)
            {
                Destroy(activeTerrains[i]);
                activeTerrains.RemoveAt(i);
            }
        }
    }
}

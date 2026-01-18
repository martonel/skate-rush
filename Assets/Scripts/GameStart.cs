using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().points = 0;
    }
}

using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;
    public TMP_Text pointText;
    private Data data;

    private GameObject endResultText;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GetComponent<Data>();
        if (pointText != null)
        {
            pointText.text = "Points: 0";
        }
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int number)
    {
        points+=number;
        if(pointText == null)
        {
            pointText = GameObject.FindGameObjectWithTag("PointText").GetComponent<TMP_Text>();
        }


        pointText.text = "Points: " +  points.ToString();
        if(points > data.maxResultNumber)
        {
            data.maxResultNumber = points;
        }

        CheckeEndResultText();
    }

    private void CheckeEndResultText()
    {
        if (endResultText == null)
        {
            endResultText = GameObject.FindGameObjectWithTag("EndResultText");
        }
        endResultText.GetComponent<TMP_Text>().text = "MAX RESULT: " + data.maxResultNumber;
    }
}

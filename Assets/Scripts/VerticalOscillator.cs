using UnityEngine;

public class VerticalOscillator : MonoBehaviour
{
    public float minY = 6f;
    public float maxY = 16f;
    public float cycleDuration = 120f; // 2 perc = 120 másodperc (1 perc fel, 1 perc le)

    private float startTime;
    private float baseX;
    private float baseZ;

    public GameObject player;

    void Start()
    {
        startTime = Time.time;
        baseX = transform.position.x;
        baseZ = transform.position.z;
    }

    void Update()
    {
        float elapsed = (Time.time - startTime) % cycleDuration;
        float t = elapsed / (cycleDuration / 2f); // 0–1 oda, 1–2 vissza

        float y;
        if (t <= 1f)
            y = Mathf.Lerp(minY, maxY, t);
        else
            y = Mathf.Lerp(maxY, minY, t - 1f);

        transform.position = new Vector3(baseX, y, baseZ);
    }
}

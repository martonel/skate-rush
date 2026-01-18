using UnityEngine;

public class FogMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;

    public Transform player;
    public float smoothY = 2f;  // minél nagyobb, annál gyorsabb a követés

    void Update()
    {
        // Mozgatás balra
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        float targetY = Mathf.Lerp(transform.position.y, player.transform.position.y, smoothY * Time.deltaTime);
    }
}

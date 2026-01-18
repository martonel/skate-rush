using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float smoothY = 2f;
    public bool isFollowX = false;// minél nagyobb, annál gyorsabb a követés

    void Update()
    {
        float targetX = player.transform.position.x;
        float targetY = transform.position.y;
        if (!isFollowX)
        {
            targetY = Mathf.Lerp(transform.position.y, player.transform.position.y, smoothY * Time.deltaTime);
        }
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}

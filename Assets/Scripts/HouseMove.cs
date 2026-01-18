using UnityEngine;

public class HouseMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;
    public float destroyDistance = 30f;
    public Transform player;

    void Update()
    {
        // Mozgatás balra
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Ha túl messze van a játékostól, törlés
        /*if (player != null && Mathf.Abs(transform.position.x - player.position.x) > destroyDistance)
        {
            Destroy(gameObject);
        }*/
    }
}

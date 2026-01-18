using UnityEngine;

public class RockDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide!");
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamage();
        }
    }
}

using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coinPoint = 1;
    public bool coinAnimVisible = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(coinAnimVisible)
            {
                GameObject.FindGameObjectWithTag("CoinText").GetComponent<Animator>().Play("CoinUp");

                GameObject.FindGameObjectWithTag("SoundManager").transform.GetChild(1).GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.FindGameObjectWithTag("SoundManager").transform.GetChild(0).GetComponent<AudioSource>().Play();
            }
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().AddPoint(coinPoint);
            
            Destroy(this.gameObject);
        }
    }
}

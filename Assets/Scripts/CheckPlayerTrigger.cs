using UnityEngine;

public class CheckPlayerTrigger : MonoBehaviour
{
    public Animator anim;
    public string animationName;
    public string tag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == tag)
        {
            if (animationName == "shipUpAnim")
            {
                Debug.Log("ship down " + collision.tag);
            }
            anim.Play(animationName);
        }
    }

}

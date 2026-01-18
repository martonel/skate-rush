using UnityEngine;

public class PrefabVisible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      bool show = Random.value > 0.5f;

      gameObject.SetActive(show);
        
    }
}

using UnityEngine;

public class CollectibleItem : MonoBehaviour
{

    public string itemName;
    public int itemValue=1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Si choco");
            
            Destroy(gameObject); 
        }
    }
}

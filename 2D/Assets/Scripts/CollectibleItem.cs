using System.ComponentModel;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum ItemType
    {
        Apple,
        Banana
    }

    public ItemType type = ItemType.Apple;
    public int itemValue = 1;

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
        if (collision.CompareTag("Player")) return;
        switch (type)
        {
            case ItemType.Apple:
                GameManager.Instance.TotalApples(itemValue);
                break;
            case ItemType.Banana:
                GameManager.Instance.TotalBanana(itemValue);
                break;

        }
        Destroy(gameObject);

    }
}

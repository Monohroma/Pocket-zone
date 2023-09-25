using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldObject : MonoBehaviour
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private SpriteRenderer sr;
    private void Awake()
    {
        if(item != null)
            sr.sprite = item.Icon;
    }

    public void SetItem(Item i)
    {
        if (i == null)
            return;
        item = i;
        sr.sprite = i.Icon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(Inventory.Instance.TryAddItem(item))
            {
                Destroy(gameObject);
            }
        }
    }
}

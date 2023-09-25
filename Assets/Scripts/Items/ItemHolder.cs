using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    private static ItemHolder _instance;
    public static ItemHolder Instance => _instance;

    [SerializeField]
    private List<Item> items;
    public List<Item> Items => items;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
    }

    public Item GetItemByName(string name)
    {
        return items.Find(x => x.Name == name);
    }
}

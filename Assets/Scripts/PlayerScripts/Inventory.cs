using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance;
    public static Inventory Instance => _instance;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
    }
    private Item[] items = new Item[4];

    public bool TryAddItem(Item it)
    {
        for(int i=0;i<items.Length;i++)
        {
            if (items[i] == null)
            {
                items[i] = Item.CreateInst(it);
                UIManager.Instance.InventoryUI.SetItem(items[i], i);
                SaveManager.Instance.Save();
                return true;
            }
        }
        return false;
    }

    private void SetItemBySlot(Item it, int i)
    {
        if (i < 0 || i >= items.Length)
            return;
        items[i] = Item.CreateInst(it);
        UIManager.Instance.InventoryUI.SetItem(items[i], i);
    }

    public void DeliteItemById(int id)
    {
        if (id < 0 || id >= items.Length)
            return;
        items[id] = null;
        UIManager.Instance.InventoryUI.ClearElementById(id);
    }

    public bool UseBullet()
    {
        for(int i=0;i<items.Length;i++)
        {
            if (items[i] == null)
                continue;
            if(items[i].Name == "BulletItem")
            {
                items[i].Count--;
                UIManager.Instance.InventoryUI.UpdateCounts(i);
                if(items[i].Count <= 0)
                    DeliteItemById(i);
                SaveManager.Instance.Save();
                return true;
            }
        }
        return false;
    }

    public void Load(SaveFile saveFile)
    {
        for(int i=0;i<saveFile.itemsInInventory.Count;i++)
        {
            if (saveFile.itemsInInventory[i] != null && saveFile.itemsInInventory[i].Count != -1)
                SetItemBySlot(saveFile.itemsInInventory[i].CreateInstanceByItem(ItemHolder.Instance.GetItemByName(saveFile.itemsInInventory[i].Name)) , i);
        }
    }

    public void Save(SaveFile saveFile)
    {
        for (int i = 0; i < items.Length; i++)
        {
            saveFile.itemsInInventory.Add(new ItemSaveData(items[i]));
        }
    }
}

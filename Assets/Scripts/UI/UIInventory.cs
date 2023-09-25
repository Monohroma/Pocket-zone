using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject deleteButton;
    private int _selectedSlotId = -1;
    [Serializable]
    public struct UIElement
    {
        public Item item;
        public Image icon;
        public Text count;

        public void UpdateCount()
        {
            if (item.Count > 1)
                count.text = item.Count.ToString();
            else
                count.text = "";
        }

        public void Clear()
        {
            item = null;
            icon.sprite = null;
            count.text = "";
        }
    }

    [SerializeField]
    private UIElement[] inventoryElements;

    private void OnEnable()
    {
        deleteButton.SetActive(false);
    }

    public void SelectForDelite(int id)
    {
        if (id < 0 || id >= inventoryElements.Length)
            return;
        if (inventoryElements[id].item == null)
        {
            _selectedSlotId = -1;
            deleteButton.SetActive(false);
        }
        else
        {
            _selectedSlotId = id;
            deleteButton.SetActive(true);
        }
    }

    public void UpdateCounts()
    {
        for (int i = 0; i < inventoryElements.Length; i++)
        {
            inventoryElements[i].UpdateCount();
        }
    }

    public void UpdateCounts(int id)
    {
        if (id < 0 || id >= inventoryElements.Length)
            return;
        inventoryElements[id].UpdateCount();
    }

    public void Delite()
    {
        if (_selectedSlotId == -1)
            return;
        if (_selectedSlotId < 0 || _selectedSlotId >= inventoryElements.Length)
            return;
        Inventory.Instance.DeliteItemById(_selectedSlotId);
        deleteButton.SetActive(false);
        SaveManager.Instance.Save();
    }

    public void ClearElementById(int id)
    {
        inventoryElements[id].Clear();
    }

    public void SetItem(Item i, int slot)
    {
        if (slot < 0 || slot >= inventoryElements.Length)
            return;
        inventoryElements[slot].item = i;
        inventoryElements[slot].icon.sprite = i.Icon;
        inventoryElements[slot].UpdateCount();
    }
}

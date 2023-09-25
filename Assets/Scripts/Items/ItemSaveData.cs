using System;

[Serializable]
public class ItemSaveData
{
    public string Name = "";
    public int Count = -1;

    public ItemSaveData(string name, int count)
    {
        Name = name;
        Count = count;
    }
    public ItemSaveData(Item i)
    {
        if (i == null)
            return;
        Name = i.Name;
        Count = i.Count;
    }
    public Item CreateInstanceByItem(Item i)
    {
        return Item.CreateInst(Name, i.Icon, Count);
    }
}
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 51)]
public class Item : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name => _name;
    [SerializeField]
    private Sprite icon;
    public Sprite Icon => icon;
    [SerializeField]
    private int count;
    private bool _isInstance = false;
    public int Count { set { if (_isInstance) count = value; } get { return count; } }

    public void SetupParametrs(string n, Sprite i, int c)
    {
        _name = n;
        icon = i;
        count = c;
        _isInstance = true;
    }
    public static Item CreateInst(string n, Sprite i, int c)
    {
        Item it = CreateInstance<Item>();
        it.SetupParametrs(n, i, c);
        return it;
    }

    public static Item CreateInst(Item i)
    {
        Item it = CreateInstance<Item>();
        it.SetupParametrs(i.Name, i.Icon, i.Count);
        return it;
    }
}
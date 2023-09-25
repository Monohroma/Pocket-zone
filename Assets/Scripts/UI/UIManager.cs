using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance => _instance;

    [SerializeField]
    private RectTransform canvasRect;
    public RectTransform CanvasRect => canvasRect;

    [SerializeField]
    private Canvas managerCanvas;
    public Canvas ManagerCanvas => managerCanvas;

    [SerializeField]
    private Joystick joystick;
    public Joystick Joystick => joystick;

    [SerializeField]
    private UIInventory inventoryUI;
    public UIInventory InventoryUI => inventoryUI;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ShootButtonPresed()
    {
        Player.Instance?.Shoot();
    }

    public void HideShowBackpackPanel()
    {
        inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
    }
}

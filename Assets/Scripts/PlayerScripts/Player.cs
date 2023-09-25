using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageble
{
    private static Player _instance;
    public static Player Instance => _instance;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Rigidbody2D rig;
    [SerializeField]
    private Weapon currentWeapon;

    protected override void Awake()
    {
        base.Awake();
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        if(UIManager.Instance != null)
        {
            if(UIManager.Instance.Joystick.Vector != Vector2.zero)
            {
                rig.velocity = UIManager.Instance.Joystick.Vector * speed;
            }
        }
    }

    public void Shoot()
    {
        Debug.LogWarning("Shoot");
        currentWeapon.Shoot();
    }
}

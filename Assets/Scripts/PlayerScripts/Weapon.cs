using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private LayerMask hitLayer;
    [SerializeField]
    private float shootRange = 10;
    [SerializeField]
    private int damage = 1;

    public void Shoot()
    {
        if (!isActiveAndEnabled)
            return;
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, shootRange, hitLayer);
        Damageble dmg = null;
        float dist = -1;
        foreach (var item in targets)
        {
            if (item.tag != "Monster")
                continue;
            Damageble dmgt = item.GetComponent<Damageble>();
            if (dmgt == null)
                continue;
            if(dmg==null)
            {
                dmg = dmgt;
                if (dmg != null)
                    dist = Vector2.Distance(transform.position, item.transform.position);
                continue;
            }
            float td = Vector2.Distance(transform.position, item.transform.position);
            if(td < dist)
            {
                dmg = dmgt;
                dist = td;
            }
        }
        if (dmg == null)
            return;
        if(Inventory.Instance.UseBullet())
            dmg.GetDamage(damage);
    }
}

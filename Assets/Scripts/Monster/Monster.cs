using UnityEngine;

public class Monster : Damageble
{
    [SerializeField]
    private Rigidbody2D rig;
    [SerializeField]
    private float speed = 9f;
    [SerializeField]
    private float agressiveRadius = 8f;
    [SerializeField]
    private float atackDistance = 1f;
    [SerializeField]
    private float stopDistance = 1.5f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float atackCooldown = 1f;
    [SerializeField]
    private ItemWorldObject itemWorldObject;
    [SerializeField]
    private Item dropItem;
    private float atackCooldownTimer = 0;
    private bool agred = false;
    private void Start()
    {
        itemWorldObject.SetItem(dropItem);
    }
    private void FixedUpdate()
    {
        if (Player.Instance == null)
            return;
        if (Player.Instance.Health <= 0)
            return;
        float distanceToPlayer = Vector2.Distance(transform.position, Player.Instance.transform.position);
        if (agred)
        {
            if(distanceToPlayer > stopDistance)
                rig.velocity = (Player.Instance.transform.position - transform.position).normalized * speed;
            if (atackCooldownTimer <= 0)
            {
                if(distanceToPlayer <= atackDistance)
                {
                    Player.Instance.GetDamage(damage);
                    atackCooldownTimer = atackCooldown;
                }
            }
            else
            {
                atackCooldownTimer -= Time.fixedDeltaTime;
            }
            return;
        }
        if (distanceToPlayer <= agressiveRadius)
            agred = true;
    }

    public override void GetDamage(int dmg = 1)
    {
        base.GetDamage(dmg);
        agred = true;
    }

    public override void Death()
    {
        itemWorldObject.transform.parent = null;
        itemWorldObject.gameObject.SetActive(true);
        itemWorldObject = null;
        base.Death();
    }
}

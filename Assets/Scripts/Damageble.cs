using System;
using UnityEngine;

public abstract class Damageble : MonoBehaviour
{
    [SerializeField]
    private int startHealth = 10;
    private int currentHealth;
    public int Health => currentHealth;
    public int StartHealth => startHealth;
    public Action OnTakeDamage;

    protected virtual void Awake()
    {
        currentHealth = startHealth;
    }

    public virtual void GetDamage(int dmg = 1)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Death();
        }
        OnTakeDamage?.Invoke();
    }

    public virtual void Death()
    {
        currentHealth = 0;
        gameObject.SetActive(false);
    }

    public float GetHealthByProcent()
    {
        if (StartHealth == 0)
            return 0;
        return Health / (float)StartHealth;
    }
}

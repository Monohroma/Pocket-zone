using UnityEngine;
using UnityEngine.UI;

public class HealthbarWatcher : MonoBehaviour
{
    [SerializeField]
    private Slider health;
    [SerializeField]
    private Damageble damagebleTarget;

    private void Awake()
    {
        damagebleTarget.OnTakeDamage += OnTakeDamage;
    }

    private void OnTakeDamage()
    {
        health.value = damagebleTarget.GetHealthByProcent();
    }
}

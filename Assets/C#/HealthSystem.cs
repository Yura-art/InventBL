using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int currentHeal;
    [SerializeField] int maxHeal;

    private void Start()
    {
        currentHeal = maxHeal;
    }

    public void ReciveHeal(int heal = 25)
    {
        currentHeal += heal;
        if (currentHeal > maxHeal)
        {
            currentHeal = maxHeal;
        }
    }
    public void ReceiveDamage(int damage)
    {
        if (currentHeal <= 0)
        {
            Debug.Log("Se murio");
            Destroy(gameObject);
        }
    }
}

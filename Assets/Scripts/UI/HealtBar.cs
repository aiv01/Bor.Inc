using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] Image healthBar;
    private float currentHealth;
    private float maxHealth;
    [SerializeField]ExplorerController ellen;

    private void Start()
    {
       maxHealth = ellen.MaxHp;
    }
    private void Update()
    {
        currentHealth = ellen.CurrentHp;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}

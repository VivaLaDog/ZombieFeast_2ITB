using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    private int damage;
    public int Damage => damage;

    private MeshRenderer meshRenderer;

    [SerializeField]
    private float maxHp;
    private float currentHp;


    [SerializeField]
    private Image hpBar;

    private float CurrentHp
    {
        set
        {
            currentHp = Mathf.Max(value, 0);
            hpBar.fillAmount = currentHp / maxHp;
        }
    }

    private void Awake()
    {   
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        //currentHp = maxHp;
        CurrentHp = maxHp;
    }

    public void SetType(Material color, int damage)
    {
        meshRenderer.material = color;
        this.damage = damage;
    }

    public void TakeDamage(float take)
    {
        CurrentHp = currentHp - take;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

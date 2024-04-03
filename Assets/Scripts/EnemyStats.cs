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

    private int CurrentHp
    {
        set
        {
            currentHp = Mathf.Max(value, 0f);
            hpBar.fillAmount = currentHp / maxHp;
        }
    }

    private void Awake()
    {   
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public void SetType(Material color, int damage)
    {
        meshRenderer.material = color;
        this.damage = damage;
    }
}

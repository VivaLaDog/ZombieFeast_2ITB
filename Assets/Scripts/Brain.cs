using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyMovement>();
        if(enemy != null)
        {
            GameManager.Instance.EndGame();
        }
    }
}

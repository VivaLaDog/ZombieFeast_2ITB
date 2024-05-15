using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        DeadMaus();
        AOECheckAndAttack();
    }

    private void AOECheckAndAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GameManager.Instance.score < 5)
            {
                return;
            }
            else
            {
                GameManager.Instance.score -= 5;

                var ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 150f))
                {
                    var ground = hit.collider.GetComponent<MeshFilter>();

                    if (ground != null)
                    {
                        Debug.Log(ground.sharedMesh.name);
                        if(ground.sharedMesh.name == "Plane")
                        {

                        }
                        Debug.Log(GameManager.Instance.score);
                    }

                }
            }
        }
    }
    

    void DeadMaus()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 150f))
            {
                var enemy = hit.collider.GetComponentInParent<EnemyStats>();
                if (enemy != null)
                    enemy.TakeDamage(50);
            }
        }
    }
}

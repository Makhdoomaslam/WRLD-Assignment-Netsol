using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    bool isTargetSelected = false;
    private void FixedUpdate()
    {
        int layerMask = 1 << 6;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hit, Mathf.Infinity, layerMask))
        {
            GameObject enemy = hit.transform.gameObject;
            enemy.layer = 0;
            transform.parent.GetComponent<Player>().FoundEnemy(enemy);
            isTargetSelected = true;
        }
    }
}

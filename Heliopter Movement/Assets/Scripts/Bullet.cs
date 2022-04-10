using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float fireSpeed = 500f;
    bool isFired = false;
    Transform target;

    void Update()
    {
        if (isFired)
        {
            float step = fireSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                isFired = false;
                gameObject.SetActive(false);
                target.parent.GetComponent<Enemy>().EnemyDestruction();
            }
        }
    }

    public void BulletFired(GameObject targetEnemy)
    {
        target = targetEnemy.transform;
        isFired = true;
    }

}
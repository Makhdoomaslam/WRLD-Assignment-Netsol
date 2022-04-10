using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int playerHitsCount = 0;
    [SerializeField]
    Transform bulletsPool;


    public void GotFired()
    {
        playerHitsCount++;
        if (playerHitsCount >= 6)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            Invoke("ActivatePlayer", 3f);
        }
    }

    void ActivatePlayer()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        playerHitsCount = 0;
    }
    [SerializeField]
    GameObject target;
    public void FoundEnemy(GameObject targetEnemy)
    {
        target = targetEnemy;
        StartCoroutine(EnemyDetected());
    }

    IEnumerator EnemyDetected()
    {
        int availableBullet = Camera.main.GetComponent<MostUsedInfo>().bulletsCount;

        for (int i = 0; i < 3; i++)
        {
            if (availableBullet > 11)
                availableBullet = 0;
            Transform bullet = bulletsPool.GetChild(availableBullet);
            bullet.transform.position = transform.GetChild(1).position;
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<Bullet>().BulletFired(target);
            availableBullet++;
            yield return new WaitForSeconds(0.25f);
        }
        Camera.main.GetComponent<MostUsedInfo>().bulletsCount = availableBullet;
        yield return null;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrld;
using Wrld.Space;

public class Enemy : MonoBehaviour
{
    int destructionCounter;

    void OnEnable()
    {
      //  StartCoroutine(ActivateEnemy());
    }

    public void EnemyDestruction()
    {
        destructionCounter++;
        if (destructionCounter >= 3)
        {
            transform.GetChild(0).gameObject.SetActive(false);
           // StartCoroutine(ActivateEnemy());
        }
    }

    IEnumerator ActivateEnemy()
    {
        yield return new WaitForSeconds(Random.Range(4f, 7f));
        TouchDetector locationUpdater = GameObject.FindObjectOfType<TouchDetector>();
        LatLong enemyLocation = LatLong.FromDegrees(locationUpdater.destLat, locationUpdater.destLong);
        MakeEnemyActive(enemyLocation);
    }

    void MakeEnemyActive(LatLong latLong)
    {
        var ray = Api.Instance.SpacesApi.LatLongToVerticallyDownRay(latLong);
        LatLongAltitude buildingIntersectionPoint;
        var didIntersectBuilding = Api.Instance.BuildingsApi.TryFindIntersectionWithBuilding(ray, out buildingIntersectionPoint);
        if (didIntersectBuilding)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.layer = 6;
            destructionCounter = 0;
            transform.GetComponent<GeographicTransform>().SetPosition(buildingIntersectionPoint.GetLatLong());
            transform.localPosition = Vector3.up * (float)buildingIntersectionPoint.GetAltitude();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Wrld;
using Wrld.Space;

public class TouchDetector : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float destLat, destLong;

    public Transform helicopter;
    Vector3 initialPos;
    Vector3 defaultRot;
    void Start()
    {
        var startLocation = LatLong.FromDegrees(37.7858, -122.401);
        Api.Instance.CameraApi.MoveTo(startLocation, distanceFromInterest: 800);
        defaultRot = helicopter.eulerAngles;
        StartCoroutine(SurfaceMovement());
    }

    IEnumerator SurfaceMovement()
    {
        destLat += 0.0001f;
        var destLocation = LatLong.FromDegrees(destLat, destLong);
        Api.Instance.CameraApi.AnimateTo(destLocation, distanceFromInterest: 800, null, null, transitionDuration: 0.1, jumpIfFarAway: false);
        yield return new WaitForSeconds(0.09f);
        StartCoroutine(SurfaceMovement());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPos = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 finalPos = Input.mousePosition;
        float xdistance = finalPos.x - initialPos.x;
        if (xdistance > 1f)
        {
            initialPos = finalPos;
            helicopter.eulerAngles = new Vector3(helicopter.eulerAngles.x + 2f, 90f, -6f);
            destLong += 0.000075f;
        }
        else if (xdistance < -1)
        {
            initialPos = finalPos;
            helicopter.eulerAngles = new Vector3(helicopter.eulerAngles.x - 2f, 90f, -6f);
            destLong -= 0.000075f;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        helicopter.eulerAngles = defaultRot;
    }
}

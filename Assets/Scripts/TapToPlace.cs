using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{

    public GameObject objectToSpawn;

    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastmanager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastmanager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default; 
        return false;
    }

    void Update()
    {
        //Checking if there is a touch
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;


        //If the touch is within the plane on screen an object will spawn. Then you can move the object with more touches
        if(_arRaycastmanager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
            }
            else { spawnedObject.transform.position = hitPose.position; }
        }
    }
}

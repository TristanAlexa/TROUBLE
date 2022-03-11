/**
 * @file: Route.cs
 *        Calculates the route each player will take around board
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Route : MonoBehaviour
{
    //Calculate route. Using an array of all the route positions
    Transform[] childObjects;
    public List<Transform> childNodeList = new List<Transform>();

    //Visualize path lines for testing purposes
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        FillNodes();
        for (int i = 0; i < childNodeList.Count; i++)
        {
            Vector3 currentPos = childNodeList[i].position;
            if (i > 0)
            {
                //to prevent underflow if you are at starting position
                Vector3 prevPos = childNodeList[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }

    //Pathing the route between 
    void FillNodes()
    {
        childNodeList.Clear();

        childObjects = GetComponentsInChildren<Transform>();

        foreach(Transform child in childObjects)
        {
            if(child != this.transform)
            {
                childNodeList.Add(child);
            }
        }
    }
}

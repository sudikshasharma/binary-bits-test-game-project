using UnityEngine;

public class RaycastHits : MonoBehaviour
{
    void Update()
    {
        int layerMask = (1 << 8) | (1 << 9);  //Raycast will avoid cube and sphere layer
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.DrawRay(hit.point, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
        }
    }
}
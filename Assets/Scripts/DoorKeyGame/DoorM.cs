using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorM : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }
}

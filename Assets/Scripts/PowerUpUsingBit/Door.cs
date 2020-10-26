using UnityEngine;

public class Door : MonoBehaviour
{

    void OnTriggerExit(Collider player)
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }
}

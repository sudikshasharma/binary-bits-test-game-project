using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMagic : MonoBehaviour
{
    public static int magic = 1;

    void OnCollisionEnter(Collision player)
    {
        AttributeManager.attributes ^= magic;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public static int magic = 1;
    public static int fly = 2;
    public static int charisma = 4;
    public static int intelligence = 8;
    public static int invisible = 16;
    public int power = 0;

    void OnCollisionEnter(Collision obj)
    {
        Debug.Log(obj.gameObject.tag);
        if (obj.gameObject.tag == "MAGICK")
        {
            power |= magic;
            Destroy(obj.gameObject);
        }
        if (obj.gameObject.tag == "FLYK")
        {
            power |= fly;
            Destroy(obj.gameObject);
        }
        if (obj.gameObject.tag == "CHARISMAK")
        {
            power |= charisma;
            Destroy(obj.gameObject);
        }
        if (obj.gameObject.tag == "INTELLIGENCEK")
        {
            power |= intelligence;
            Destroy(obj.gameObject);
        }
        if (obj.gameObject.tag == "INVISIBLEK")
        {
            power |= invisible;
            Destroy(obj.gameObject);
        }
        if (obj.gameObject.tag == "GOLDENK")
        {
            power |= (magic | invisible | fly | charisma | intelligence);
            Destroy(obj.gameObject);
        }
        if (obj.gameObject.tag == "MAGIC")
        {
            if ((magic & power) != 0)
            {
                LetEnter(obj.gameObject, magic);
            }
        }
        if (obj.gameObject.tag == "FLY")
        {
            if ((fly & power) != 0)
            {
                LetEnter(obj.gameObject, fly);
            }
        }
        if (obj.gameObject.tag == "CHARISMA")
        {
            if ((charisma & power) != 0)
            {
                LetEnter(obj.gameObject, charisma);
            }
        }
        if (obj.gameObject.tag == "INTELLIGENCE")
        {
            if ((intelligence & power) != 0)
            {
                LetEnter(obj.gameObject, intelligence);
            }
        }
        if (obj.gameObject.tag == "INVISIBLE")
        {
            if ((invisible & power) != 0)
            {
                LetEnter(obj.gameObject, invisible);
            }
        }
    }

    void LetEnter(GameObject obj, int pow)
    {
        power &= ~pow;
        obj.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
}

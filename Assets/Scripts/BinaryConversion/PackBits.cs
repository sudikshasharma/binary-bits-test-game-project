using System;
using UnityEngine;

public class PackBits : MonoBehaviour
{
    string A = "110111";
    string B = "10001";
    string C = "1101";
    int aBits;
    int bBits;
    int cBits;
    int X = 0;

    void Start()
    {
        aBits = Convert.ToInt32(A, 2); //2 is from Base
        bBits = Convert.ToInt32(B, 2); //2 is from Base
        cBits = Convert.ToInt32(C, 2); //2 is from Base
        X |= (aBits << (32 - A.Length));
        X |= (bBits << (32 - (A.Length + B.Length)));
        X |= (cBits << (32 - (A.Length + B.Length + C.Length)));
        Debug.Log("Binary A : " + aBits + " Binary B : " + bBits + " Binary C : " + cBits + " Packing A,B,C into X, Binary X : " + Convert.ToString(X, 2).PadLeft(32, '0'));
    }
}

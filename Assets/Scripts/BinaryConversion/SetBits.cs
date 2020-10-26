using System;
using UnityEngine;
public class SetBits : MonoBehaviour
{
    [SerializeField] private int decimalNumber; // Decimal Number
    [SerializeField] private int baseNumber;    // Base to be converted to
    [SerializeField] private int bitCount;      // Total bits (number of digits) to be there in binary equivalent      
    private char extraBitDigit = '0';           // Digit used for extra bits (to the left side of the binary equivalent to cover up the bit count)
    private int binarySequence;                 // Binary equivalent of decimal

    void Start()
    {

        // Print binary equivalent of decimal with no further '0' (extraBitDigit) at left after the leftmost '1' in binary euivalent
        Debug.Log("Binary equivalent of " + decimalNumber + " is : " + Convert.ToString(decimalNumber, baseNumber));

        // Print binary equivalent of decimal with '0' (extraBitDigit) attached to the left of  the leftmost '1' in binary euivalent if number of digits/bits in binary equivalent are less than bitCount. Number of '0' is added to binary equivalent until number of digits in it is equal to bitcount
        Debug.Log("Binary equivalent of " + decimalNumber + " with bitcount of " + bitCount + " is : " + Convert.ToString(decimalNumber, baseNumber).PadLeft(bitCount, extraBitDigit));

    }
}
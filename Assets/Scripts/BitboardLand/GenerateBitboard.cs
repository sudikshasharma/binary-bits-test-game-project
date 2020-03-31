using System;
using UnityEngine;

public class GenerateBitboard : MonoBehaviour
{
    public GameObject[] tiles;
    long dirtBitBoard = 0;
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject newTile = Instantiate(tiles[(UnityEngine.Random.Range(0, tiles.Length))], new Vector3(i, 0, j), Quaternion.identity);
                if (newTile.tag == "Dirt")
                {
                    SetDirtBitBoard(i, j);
                }
            }
        }
        PrintDirtbitBoard();
    }

    void SetDirtBitBoard(int row, int col)
    {
        long dirtBit = 1 << (row * 8 + col);
        dirtBitBoard |= dirtBit;
    }

    void PrintDirtbitBoard()
    {
        Debug.Log(Convert.ToString(dirtBitBoard, 2).PadLeft(64, '0'));
    }
}

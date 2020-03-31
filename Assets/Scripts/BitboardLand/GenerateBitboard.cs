using System;
using UnityEngine;

public class GenerateBitboard : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject tree;
    GameObject[] tile;
    long dirtBitBoard = 0;
    void Start()
    {
        tile = new GameObject[64];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject newTile = Instantiate(tiles[(UnityEngine.Random.Range(0, tiles.Length))], new Vector3(i, 0, j), Quaternion.identity);
                tile[i * 8 + j] = newTile;
                if (newTile.tag == "Dirt")
                {
                    SetDirtBitBoard(i, j);
                }
            }
        }
        PrintDirtbitBoard();
        InvokeRepeating("PlantTree", 1, 1);   // Looks for dirt time after every 1 second and plant tree on it if found
    }

    void PlantTree()
    {
        int row = UnityEngine.Random.Range(0, 8);
        int col = UnityEngine.Random.Range(0, 8);
        if (GetCellStateDirt(row, col))
        {
            Debug.Log(tile[row * 8 + col].tag);
            GameObject treeObj = Instantiate(tree, new Vector3(row, 0, col), Quaternion.identity);
            treeObj.transform.parent = tile[row * 8 + col].transform;
        }
    }

    bool GetCellStateDirt(int row, int col)
    {
        long dirtBit = 1 << (row * 8 + col);
        return ((dirtBitBoard & dirtBit) != 0);
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

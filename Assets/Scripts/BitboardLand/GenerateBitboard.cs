using System;
using UnityEngine;

public class GenerateBitboard : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject tree;
    public GameObject house;
    GameObject[] tile;
    long dirtBitBoard = 0;
    long treeBitBoard = 0;
    long houseBitBoard = 0;
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
                    SetBitBoard(dirtBitBoard, i, j);
                }
            }
        }
        PrintDirtbitBoard();
        Debug.Log("Number of Dirt Tiles : " + CountDirtTile());
        InvokeRepeating("PlantTree", 1, 1);   // Looks for dirt time after every 1 second and plant tree on it if found
    }

    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                GameObject houseObj = Instantiate(house, new Vector3(hit.collider.gameObject.transform.position.x, 0, hit.collider.gameObject.transform.position.z), Quaternion.identity);
                SetBitBoard(houseBitBoard, (int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z);
            }
        }
    }

    int CountDirtTile()
    {
        int count = 0;

        long dirtTile = dirtBitBoard;
        while (dirtTile != 0)
        {
            dirtTile &= dirtTile - 1;
            ++count;
        }
        return count;
    }

    void PlantTree()
    {
        int row = UnityEngine.Random.Range(0, 8);
        int col = UnityEngine.Random.Range(0, 8);
        if (GetCellStateDirt(row, col))
        {
            GameObject treeObj = Instantiate(tree, new Vector3(row, 0, col), Quaternion.identity);
            treeObj.transform.parent = tile[row * 8 + col].transform;
            SetBitBoard(treeBitBoard, row, col);
        }
    }

    bool GetCellStateDirt(int row, int col)
    {
        long dirtBit = 1L << (row * 8 + col);
        return ((dirtBitBoard & dirtBit) != 0);
    }

    void SetBitBoard(long bitBoard, int row, int col)
    {
        long dirtBit = 1L << (row * 8 + col);
        bitBoard |= dirtBit;
    }

    void PrintDirtbitBoard()
    {
        Debug.Log(Convert.ToString(dirtBitBoard, 2).PadLeft(64, '0'));
    }
}

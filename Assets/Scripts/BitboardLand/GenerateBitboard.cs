using System;
using UnityEngine;
using UnityEngine.UI;

public class GenerateBitboard : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject tree;
    public GameObject house;
    public Text score;
    GameObject[] tile;
    long dirtBitBoard = 0;
    long desertBitBoard = 0;
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
                    dirtBitBoard = SetBitBoard(dirtBitBoard, i, j);
                }
                if (newTile.tag == "Desert")
                {
                    desertBitBoard = SetBitBoard(desertBitBoard, i, j);
                }
            }
        }
        PrintbitBoard(dirtBitBoard);
        PrintbitBoard(desertBitBoard);
        Debug.Log("Number of Dirt Tiles : " + CountTile(dirtBitBoard));
        Debug.Log("Number of Desert Tiles : " + CountTile(desertBitBoard));
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
                if (GetCellStateDirt(dirtBitBoard & (~treeBitBoard) | desertBitBoard, (int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z))
                {
                    GameObject houseObj = Instantiate(house, new Vector3(hit.collider.gameObject.transform.position.x, 0, hit.collider.gameObject.transform.position.z), Quaternion.identity);
                    houseBitBoard = SetBitBoard(houseBitBoard, (int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z);
                    score.text = "SCORE: " + (CountTile(houseBitBoard & dirtBitBoard) * 2 + CountTile(houseBitBoard & desertBitBoard) * 10).ToString();   //Get 2 points when house built on dirt and 10 points when built on desert
                }
            }
        }
    }

    int CountTile(long bitBoard)
    {
        int count = 0;
        long dirtTile = bitBoard;
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
        if (GetCellStateDirt(((dirtBitBoard & (~houseBitBoard)) | desertBitBoard), row, col))
        {
            GameObject treeObj = Instantiate(tree, new Vector3(row, 0, col), Quaternion.identity);
            treeObj.transform.parent = tile[row * 8 + col].transform;
            treeBitBoard = SetBitBoard(treeBitBoard, row, col);
        }
    }

    bool GetCellStateDirt(long bitBoard, int row, int col)
    {
        long dirtBit = 1L << (row * 8 + col);
        return ((bitBoard & dirtBit) != 0);
    }

    long SetBitBoard(long bitBoard, int row, int col)
    {
        long dirtBit = 1L << (row * 8 + col);
        return (bitBoard |= dirtBit);
    }

    void PrintbitBoard(long bitBoard)
    {
        Debug.Log(Convert.ToString(bitBoard, 2).PadLeft(64, '0'));
    }
}

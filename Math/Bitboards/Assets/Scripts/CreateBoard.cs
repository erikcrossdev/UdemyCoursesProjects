using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class CreateBoard : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public Text score;
    long dirtBB = 0; //dirt bitboard
    void Start()
    {
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++) 
            { 
                int randomTile = UnityEngine.Random.Range(0,tilePrefabs.Length);
                Vector3 pos = new Vector3(c, 0, r);
                GameObject tile = Instantiate(tilePrefabs[randomTile], pos, Quaternion.identity);
                tile.name = string.Concat(tile.tag, "_", r, "_", c);
                switch(tile.tag)
                {
                    case "Dirt":
                        dirtBB = SetCellState(dirtBB, r, c);
                        //PrintBB("Dirt", dirtBB);
                        break;
                }
            } 
        }
        Debug.Log("Dirt cells = " + CellCount(dirtBB));
    }

    void PrintBB(string name, long BB) 
    {
        Debug.Log(name + ": " + Convert.ToString(BB,2).PadLeft(64, '0'));
    }

    long SetCellState(long bitboard, int row, int col) 
    {
        //So we need to create another bit board which
        //just represents that single tile.
        //1L - is one and Long
        long newbit = 1L << (row * 8 +col); //left shift and flatten the array
        return (bitboard |= newbit); //Add the new bit into the bitboard with or operator.
    
    }

    int CellCount(long bitboard)
    {
        int count = 0;
        long bb = bitboard;
        while(bb != 0) 
        {
            bb &= bb - 1;
            count++;
        }
        return count;
    }

    void Update()
    {
        
    }
}

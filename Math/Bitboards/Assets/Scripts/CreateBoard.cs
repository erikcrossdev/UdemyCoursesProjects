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
    public GameObject treePrefab;
    public Text score;
    GameObject[] tiles; 
    long dirtBB = 0; //dirt bitboard
    long desertBB = 0;
    long pastureBB = 0;
    long treeBB = 0; //planted tree bitboard
    long housesBB = 0;
    void Start()
    {
        tiles = new GameObject[64];
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++) 
            { 
                int randomTile = UnityEngine.Random.Range(0,tilePrefabs.Length);
                Vector3 pos = new Vector3(c, 0, r);
                GameObject tile = Instantiate(tilePrefabs[randomTile], pos, Quaternion.identity);
                tile.name = string.Concat(tile.tag, "_", r, "_", c);
                tiles[r * 8 +c] = tile; //flatten board to fit in a unidimentional array
                switch(tile.tag)
                {
                    case "Dirt":
                        dirtBB = SetCellState(dirtBB, r, c);
                        //PrintBB("Dirt", dirtBB);
                        break;
                    case "Desert":
                        desertBB = SetCellState(desertBB, r, c);
                        break;
                    case "Pasture":
                        pastureBB = SetCellState(pastureBB, r, c);
                        break;
                }
            } 
        }
        //Debug.Log("Dirt cells = " + CellCount(dirtBB));
        InvokeRepeating(nameof(PlantTree), 1, 1);
    }

    void PlantTree() {

        int randRow = UnityEngine.Random.Range(0, 8);
        int randCol = UnityEngine.Random.Range(0, 8);
        if(GetCellState(dirtBB & ~housesBB, randRow, randCol))
        { //dirtBB & ~housesBB will make that a tree would never be planted where a house is!
            GameObject tree = Instantiate(treePrefab);
            tree.transform.parent = tiles[randRow * 8 +randCol].transform;
            tree.transform.localPosition = Vector3.zero;
            treeBB = SetCellState(treeBB, randRow, randCol);
        }
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

    bool GetCellState(long bitboard, int row, int col) {
        long mask = 1L << (row * 8 +col);
        return ((bitboard & mask) != 0); //return 1 or 0, true or false. & returns true only with 1 & 1 = 1, 1 & 0 =0 and 0 & 0 = 0
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

    void CalculateScore() {

        score.text = "Score: " + 
            (CellCount(dirtBB & housesBB) * 10
            + CellCount(desertBB & housesBB) * 2); //Count score for each house placed
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 hitTransform = hit.collider.gameObject.transform.position;
                int r = (int)hitTransform.z;
                int c = (int)hitTransform.x;

                //not leting place a house where there is a tree and only on dirt and desert tiles
                if (!GetCellState((dirtBB) & ~treeBB | desertBB, r, c)) return; // dirt and no tree or desert

                GameObject house = Instantiate(housePrefab);
                house.transform.parent = hit.collider.gameObject.transform;
                house.transform.localPosition = Vector3.zero;
                housesBB = SetCellState(housesBB, r, c);//since the tiles are one unity distant form one another, it will work!
                CalculateScore();
            }
        }
    }
}

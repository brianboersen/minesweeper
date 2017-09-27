using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{
    private Grid grid;

	void Awake ()
    {
        grid = GameObject.Find("Gamemanager").GetComponent<Grid>();
	}

    public bool isBomb (int num)
    {
        bool bol = false;

        if(grid.getTileByNumber(num).GetComponent<TileInfo>().bomb == true)
        {
            bol = true;
        }

        return bol;
	}

    public bool isEmpty (int num)
    {
        bool bol = false;

        if (grid.getTileByNumber(num).GetComponent<TileInfo>().tileNumber == 0)
        {
            bol = true;
        }

        return bol;
    }

    public bool isNumberd (int num)
    {
        bool bol = false;

        if (grid.getTileByNumber(num).GetComponent<TileInfo>().tileNumber > 0)
        {
            bol = true;
        }

        return bol;
    }
}

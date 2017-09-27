using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float tileDistance = 0.1f;

    public GameObject[,] fieldGrid = new GameObject[9,9];

    public void gridinitialization()
    {
        TileSetup tileSetup = GetComponent<TileSetup>();

        for (int x = 0; x < fieldGrid.GetLength(0); x++)
        {
            for (int y = 0; y < fieldGrid.GetLength(1); y++)
            {
                GameObject newtile = tileSetup.newTile();
                RectTransform trans = newtile.GetComponent<RectTransform>();
                TileInfo info = newtile.GetComponent<TileInfo>();

                trans.localPosition = new Vector2(trans.localPosition.x - ((trans.sizeDelta.x * (1 + tileDistance)) * (((fieldGrid.GetLength(0) - (fieldGrid.GetLength(0) % 2)) / 2) - x)), trans.localPosition.y - ((trans.sizeDelta.y * (1 + tileDistance)) * (((fieldGrid.GetLength(0) - (fieldGrid.GetLength(0) % 2)) / 2) - y)));

                info.tileNumber = y + (fieldGrid.GetLength(1) * x);
                info.tilePlace = new Vector2(x, y);

                fieldGrid[x, y] = newtile;
            }
        }
    }

    public int numToX (int number)
    {      
        return ( number - ( number % fieldGrid.GetLength (1) ) ) / fieldGrid.GetLength (0);
    }

    public int numToY (int number)
    {
        return number % fieldGrid.GetLength(1);
    }

    public GameObject getTileByNumber (int num)
    {
        return fieldGrid[(num - (num % fieldGrid.GetLength(1))) / fieldGrid.GetLength(0), num % fieldGrid.GetLength(1)];
    }

    public int gridToNum (int x,int y)
    {
        return (fieldGrid.GetLength(0) * x) + y;
    }

    public bool inbounds (int x,int y)
    {
        if(x >= 0 && x < fieldGrid.GetLength(0))
        {
            if(y >= 0 && y < fieldGrid.GetLength(1))
            {
                return true;
            }
        }

        return false;
    }
}

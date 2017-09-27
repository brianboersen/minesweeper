using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberFill : MonoBehaviour
{
    private Grid grid;
    private TileCheck tilecheck;

    private Vector2[] step = new Vector2[8] {new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0), new Vector2(1,1), new Vector2(1,-1), new Vector2(-1,-1), new Vector2(-1,1) };
    
	void Awake ()
    {
        grid = GetComponent<Grid>();
        tilecheck = GetComponent<TileCheck>();
	}
	
	public void fillAll ()
    {
        Vector2 currentTile = new Vector2();

        for (int x = 0; x < grid.fieldGrid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.fieldGrid.GetLength(1); y++)
            {
                if (tilecheck.isBomb(grid.gridToNum(x, y)) == false)
                {
                    int bombCount = 0;

                    for (int j = 0; j < 8; j++)
                    {
                        currentTile = new Vector2(x, y);
                        currentTile += step[j];

                        if (grid.inbounds((int)currentTile.x, (int)currentTile.y) == true)
                        {
                            if (tilecheck.isBomb(grid.gridToNum((int)currentTile.x, (int)currentTile.y)) == true)
                            {
                                bombCount++;
                            }
                        }

                    }

                    if(bombCount > 0)
                    grid.fieldGrid[x, y].GetComponent<TileInfo>().bombsTouching(bombCount);

                }
            }
        }
	}
}

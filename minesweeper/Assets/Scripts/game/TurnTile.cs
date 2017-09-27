using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTile : MonoBehaviour
{
    private Grid grid;
    private TileColor tileColor;
    private TileCheck check;

    private List<Vector2> tilesToTest = new List<Vector2>();

    private Vector2[] step = new Vector2[8] { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0), new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1) };

    void Start ()
    {
        grid = GetComponent<Grid>();
        tileColor = GetComponent<TileColor>();
        check = GetComponent<TileCheck>();
	}

    public void turn(TileInfo info)
    {
        if (info.bomb == true)
        {
            GetComponent<Restart>().restart();
        }
        else if(info.bombsInVicinity > 0)
        {
            tileColor.set(info.gameObject, info.bombsInVicinity);
            turnOver(info);
        }
        else
        {
            turnOver(info);
            sweep(info);
        }
    }

    private void sweep(TileInfo info)
    {
        bool done = false;

        Vector2 currentTilePos = info.tilePlace;
        
        testStraight(currentTilePos);
        
        testDiaganal(currentTilePos);
        
        while (done == false)
        {
            if (tilesToTest.Count == 0)
            {
                done = true;
                break;
            }
            else
            {
                currentTilePos = tilesToTest[0];

                testStraight(currentTilePos);

                testDiaganal(currentTilePos);

                tilesToTest.Remove(currentTilePos);
            }
        }
        
    }

    private void turnOver(TileInfo info)
    {
        info.gameObject.GetComponent<Button>().interactable = false;
        info.tileTurend = true;
    }

    private void testStraight(Vector2 tilePos)
    {
        Vector2 testTilePos;
        TileInfo testObjectInfo;

        for (int i = 0; i < 4; i++)
        {
            testTilePos = tilePos + step[i];

            if (grid.inbounds((int)testTilePos.x, (int)testTilePos.y))
            { 
                testObjectInfo = grid.fieldGrid[(int)testTilePos.x, (int)testTilePos.y].GetComponent<TileInfo>();
                if (testObjectInfo.tileTurend == false)
                {
                    if (testObjectInfo.bombsInVicinity == 0)
                    {
                        tilesToTest.Add(testTilePos);
                    }
                    else
                    {
                        tileColor.set(testObjectInfo.gameObject, testObjectInfo.bombsInVicinity);
                    }

                    turnOver(testObjectInfo);
                }

            }
        }
    }

    private void testDiaganal(Vector2 tilePos)
    {
        Vector2 testTilePos;
        TileInfo testObjectInfo;

        for (int j = 4; j < 8; j++)
        {
            testTilePos = tilePos + step[j];

            if (grid.inbounds((int)testTilePos.x, (int)testTilePos.y))
            {
                testObjectInfo = grid.fieldGrid[(int)testTilePos.x, (int)testTilePos.y].GetComponent<TileInfo>();

                if (testObjectInfo.tileTurend == false)
                {
                    if (testObjectInfo.bombsInVicinity > 0)
                    {
                        tileColor.set(testObjectInfo.gameObject, testObjectInfo.bombsInVicinity);
                        turnOver(testObjectInfo);
                    }
                }
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlanting : MonoBehaviour
{ 
    public void plant (Grid grid, int bombCount)
    {
        for (int i = 0; i < bombCount; i++)
        {
            bool bombset = false;
            int rand;

            while (bombset == false)
            {
                rand = Random.Range(0, 80);

                if (grid.getTileByNumber(rand).gameObject.GetComponent<TileInfo>().bomb == false)
                {
                    grid.getTileByNumber(rand).gameObject.GetComponent<TileInfo>().setBomb();
                    bombset = true;
                }
            }
        }
    }
}

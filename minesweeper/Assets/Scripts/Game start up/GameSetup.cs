using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField]
    private int bombCount = 10;

    public int BombCount
    {
        get { return bombCount; }
    }

    private Grid grid;
    private NumberFill numberFill;
    private BombPlanting bombPlanting;

    void Awake()
    {
        grid = GetComponent<Grid>();
        numberFill = GetComponent<NumberFill>();
        bombPlanting = GetComponent<BombPlanting>();
    }

    void Start ()
    {
        grid.gridinitialization();
        bombPlanting.plant(grid, bombCount);
        numberFill.fillAll();
    }

    
}

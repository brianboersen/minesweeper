using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileColor : MonoBehaviour
{
    private Color32[] numberColor = new Color32[8] 
        {   new Color32(58, 133, 255, 255),
            new Color32(33, 153, 37, 255),
            new Color32(255, 56, 139, 255),
            new Color32(59, 55, 255, 255),
            new Color32(174, 32, 214, 255),
            new Color32(214, 32, 41, 255),
            new Color32(255, 120, 10, 255),
            new Color32(255, 219, 40, 255)
        };

    public void set (GameObject tile, int mines)
    {
        Text tileText = tile.GetComponentInChildren<Text>();
        tileText.text = mines + "";
        tileText.color = numberColor[mines -1];
    }
}

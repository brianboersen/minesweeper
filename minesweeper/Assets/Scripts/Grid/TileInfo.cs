using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInfo : MonoBehaviour
{
    public bool tileTurend = false; 

    public int tileNumber;

    public Vector2 tilePlace;

    public bool bomb = false;

    public int bombsInVicinity = 0;

    public void setBomb ()
    {
        bomb = true;
        //this.gameObject.GetComponentInChildren<Text>().text = "B";
	}

	public void bombsTouching (int count)
    {
        bombsInVicinity = count;
        //GameObject.Find("Gamemanager").GetComponent<TileColor>().set(this.gameObject, bombsInVicinity);
    }
}

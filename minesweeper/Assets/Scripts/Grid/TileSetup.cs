using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSetup : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;

    private Button button;

    public GameObject newTile()
    {
        GameObject tile = Instantiate(tilePrefab, Vector2.zero, Quaternion.identity);
        RectTransform trans = tile.GetComponent<RectTransform>();

        tile.transform.parent = GameObject.Find("Canvas").transform;
        trans.localScale = new Vector3(1, 1, 1);

        trans.localPosition = new Vector2(0, 0);

        button = tile.GetComponent<Button>();
        button.onClick.AddListener(() => { GetComponent<TurnTile>().turn( tile.GetComponent<TileInfo>() ); });

        return tile;
    }
}

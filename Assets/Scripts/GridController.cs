using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap pathMap = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile greenTile = null;

    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        //if (!mousePos.Equals(previousMousePos))
        //{
        //    interactiveMap.SetTile(previousMousePos, greenTile); // Remove old hoverTile
        //    interactiveMap.SetTile(mousePos, hoverTile);
        //    previousMousePos = mousePos;
        //}

        // Left mouse click -> add path tile
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactiveMap.SetTile(mousePos, null);
        }

    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
//need to make a rule tile which tessts for bombs and shows different numbers

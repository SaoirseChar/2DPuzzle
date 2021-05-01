using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap pathMap = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile greenTile = null;

    [SerializeField] private GameObject playerObject;

    [Header("Radar")]
    public int radarUses = 3;
    public Text radarText;

    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level 2")
        {
            radarUses = 5;
        }
        else if (scene.name == "Level 3")
        {
            radarUses = 8;
        }
        radarText.text = "Radar Uses: " + radarUses;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int playerPos = GetPlayerPosition();
        Vector3Int playerPosUp = GetPlayerPositionUp();
        Vector3Int playerPosDown = GetPlayerPositionDown();
        Vector3Int playerPosLeft = GetPlayerPositionLeft();
        Vector3Int playerPosRight = GetPlayerPositionRight();
        Vector3Int playerPosUpLeft = GetPlayerPositionUpLeft();
        Vector3Int playerPosUpRight = GetPlayerPositionUpRight();
        Vector3Int playerPosDownLeft = GetPlayerPositionDownLeft();
        Vector3Int playerPosDownRight = GetPlayerPositionDownRight();


        // Left mouse click -> add path tile
        if (Input.GetKeyDown(KeyCode.E) && radarUses > 0)
        {
            Radar();
            interactiveMap.SetTile(playerPos, null);
            interactiveMap.SetTile(playerPosUp, null);
            interactiveMap.SetTile(playerPosDown, null);
            interactiveMap.SetTile(playerPosLeft, null);
            interactiveMap.SetTile(playerPosRight, null);
            interactiveMap.SetTile(playerPosUpLeft, null);
            interactiveMap.SetTile(playerPosUpRight, null);
            interactiveMap.SetTile(playerPosDownLeft, null);
            interactiveMap.SetTile(playerPosDownRight, null);
        }

    }
    
    Vector3Int GetPlayerPosition()
    {
        Vector3 playerWorldPosition = playerObject.transform.position;
        return grid.WorldToCell(playerWorldPosition);
    }

    Vector3Int GetPlayerPositionUp()
    {
        Vector3 playerWorldPositionUp = playerObject.transform.position + new Vector3(0,1,0);
        return grid.WorldToCell(playerWorldPositionUp);
    }
    Vector3Int GetPlayerPositionDown()
    {
        Vector3 playerWorldPositionDown = playerObject.transform.position + new Vector3(0, -1, 0);
        return grid.WorldToCell(playerWorldPositionDown);
    }
    Vector3Int GetPlayerPositionLeft()
    {
        Vector3 playerWorldPositionLeft = playerObject.transform.position + new Vector3(-1, 0, 0);
        return grid.WorldToCell(playerWorldPositionLeft);
    }
    Vector3Int GetPlayerPositionRight()
    {
        Vector3 playerWorldPositionRight = playerObject.transform.position + new Vector3(1, 0, 0);
        return grid.WorldToCell(playerWorldPositionRight);
    }
    Vector3Int GetPlayerPositionUpLeft()
    {
        Vector3 playerWorldPositionUpLeft = playerObject.transform.position + new Vector3(-1, 1, 0);
        return grid.WorldToCell(playerWorldPositionUpLeft);
    }
    Vector3Int GetPlayerPositionUpRight()
    {
        Vector3 playerWorldPositionUpRight = playerObject.transform.position + new Vector3(1, 1, 0);
        return grid.WorldToCell(playerWorldPositionUpRight);
    }
    Vector3Int GetPlayerPositionDownLeft()
    {
        Vector3 playerWorldPositionDownLeft = playerObject.transform.position + new Vector3(-1, -1, 0);
        return grid.WorldToCell(playerWorldPositionDownLeft);
    }
    Vector3Int GetPlayerPositionDownRight()
    {
        Vector3 playerWorldPositionDownRight = playerObject.transform.position + new Vector3(1, -1, 0);
        return grid.WorldToCell(playerWorldPositionDownRight);
    }

    public void Radar()
    {
        radarUses--;
        radarText.text = "Radar Uses: " + radarUses;
    }
}
//need to make a rule tile which tessts for bombs and shows different numbers

using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int ferro;
    public Text ferroDisplay;

    private Building buildingToPlace;
    public GameObject grid;

    public CustomCursor customCursor;

    public Tile[] tiles;



    public int QtdFerro{ get; private set; }

    public void UpFerro()
    {

        QtdFerro++;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ferroDisplay.text = ferro.ToString();

        if (Input.GetMouseButton(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;
            float shortestDistance = float.MaxValue;
            foreach (Tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    nearestTile = tile;
                }
            }
            if (nearestTile.isOccupied == false)
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, quaternion.identity);
                buildingToPlace = null;
                nearestTile.isOccupied = true;
                customCursor.gameObject.SetActive(false);
                Cursor.visible = true;
                grid.SetActive(false);
                
            }

        }
    }

    public void BuyBuilding(Building building)
    {
        if (ferro >= building.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;


            ferro -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }
}

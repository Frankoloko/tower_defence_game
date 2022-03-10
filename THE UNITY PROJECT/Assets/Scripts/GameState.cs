using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject hoverTower;

    private Vector3 mouseWorldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveMouseTower();
        PlaceTower();
    }

    // The logic that hover's the placeholder tower on the user's mouse position
    void MoveMouseTower()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // We do this otherwise the Z value can be a minus value, therefore hiding the object
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        hoverTower.transform.position = mouseWorldPosition;
    }

    // The logic to place a tower onto the field
    void PlaceTower()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse left click
        {
            // Spawn the tower
            mouseWorldPosition.z = 0f;
            GameObject tempObject = Instantiate(hoverTower, mouseWorldPosition, Quaternion.identity);
            
            // Make it's opcaity/alpha value solid
            SpriteRenderer renderer = tempObject.GetComponent<SpriteRenderer>();
            Color newColor = renderer.material.color;
            Debug.Log(newColor);
            newColor.a = 1;
            renderer.material.color = newColor;
        }
    }
}

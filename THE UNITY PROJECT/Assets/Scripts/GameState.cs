using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject hoverTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // We do this otherwise the Z value can be a minus value, therefore hiding the object
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        hoverTower.transform.position = mouseWorldPosition;
    }
}

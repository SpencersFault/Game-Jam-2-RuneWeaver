using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    private bool isSelected = false;

   
    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        isSelected = true;
        Debug.Log("Rune is Selected");
    }
    // Start is called before the first frame update
    private void OnMouseUp()
    {
        isSelected = false;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    private bool isSelected = false;

    private Color isRed = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Color isGreen = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    private Color isBlue = new Color(0.0f, 0.0f, 1.0f, 1.0f);
    private Color isPink = new Color(1.0f, 0.0f, 1.0f, 1.0f);
    private Color isYellow = new Color(1.0f, 0.92f, 0.016f, 1.0f);
    private Color isBlack = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    private Color isWhite = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    public string runetrait;
    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject[] gridHolder = GameObject.FindGameObjectsWithTag("gridElement");
        for (int i = 0; i < 9; i++)
        {
            if (gridHolder[i].GetComponent<SpriteRenderer>().color != isRed && gridHolder[i].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[i].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[i].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[i].GetComponent<SpriteRenderer>().color != isPink && gridHolder[i].GetComponent<SpriteRenderer>().color != isBlack)
            {
                gridHolder[i].GetComponent<RunePlacement>().runeTrait = runetrait;
            }
        }
        isSelected = true;
        //Debug.Log(runetrait + " Rune is Selected");
    }
    // Start is called before the first frame update
    private void OnMouseUp()
    {
        isSelected = false;
    }
    
}

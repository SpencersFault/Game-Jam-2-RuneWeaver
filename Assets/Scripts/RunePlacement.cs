using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePlacement : MonoBehaviour
{

    public List<GameObject> grid = new List<GameObject>();
    private GameObject[] gridHolder = new GameObject[9];
    public string runeTrait = "Fire";
    private GameObject holder;
    private GameObject current;

    private Color isRed = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Color isGreen = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    private Color isBlue = new Color(0.0f, 0.0f, 1.0f, 1.0f);
    private Color isPink = new Color(1.0f, 0.0f, 1.0f, 1.0f);
    private Color isYellow = new Color(1.0f, 0.92f, 0.016f, 1.0f);
    private Color isBlack = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    private Color isWhite = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        current = this.gameObject;
        GameObject[] gridHolder = GameObject.FindGameObjectsWithTag("gridElement");
        int thisIndex = System.Array.IndexOf(gridHolder, current);
        for (int i = 0; i < 9; i++)
        {
            if (gridHolder[thisIndex].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex].GetComponent<SpriteRenderer>().color != isBlack)
            {

                if (runeTrait == "Fire")
                {
                    if (gridHolder[thisIndex + 1].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 1].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 1].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 1].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 1].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 1].GetComponent<SpriteRenderer>().color != isBlack && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isBlack)
                    {
                        current.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0f, 0f, 0.5f);
                        gridHolder[thisIndex + 1].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0f, 0f, 0.5f);
                        gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0f, 0f, 0.5f);
                    }
                }
                else if (runeTrait == "Water")
                {
                    if (gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color != isBlack && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isBlack)
                    {
                        current.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1.0f, 0.5f);
                        gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1.0f, 0.5f);
                        gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1.0f, 0.5f);
                    }
                }
                else if (runeTrait == "Air")
                {
                    if (gridHolder[thisIndex + 4].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 4].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 4].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 4].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 4].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 4].GetComponent<SpriteRenderer>().color != isBlack && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isBlack)
                    {
                        current.GetComponent<SpriteRenderer>().color = new Color(0f, 1.0f, 0f, 0.5f);
                        gridHolder[thisIndex + 4].GetComponent<SpriteRenderer>().color = new Color(0f, 1.0f, 0f, 0.5f);
                        gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color = new Color(0f, 1.0f, 0f, 0.5f);
                    }
                }
                else if (runeTrait == "Earth")
                {
                    if (gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isBlack && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color != isBlack)
                    {
                        current.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.92f, 0.016f, 0.5f);
                        gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.92f, 0.016f, 0.5f);
                        gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.92f, 0.016f, 0.5f);
                    }
                }
                else if (runeTrait == "Charm")
                {
                    if (gridHolder[thisIndex + 2].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 2].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 2].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 2].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 2].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 2].GetComponent<SpriteRenderer>().color != isBlack && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isRed && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isPink && gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color != isBlack)
                    {
                        current.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 1.0f, 0.5f);
                        gridHolder[thisIndex + 2].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0f, 1.0f, 0.5f);
                        gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0f, 1.0f, 0.5f);
                    }
                }
                else if (runeTrait == "Flux")
                {
                    current.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.5f);
                }
            }
        }

    }

    void OnMouseDown()
    {

        current = this.gameObject;
        GameObject[] gridHolder = GameObject.FindGameObjectsWithTag("gridElement");
        int thisIndex = System.Array.IndexOf(gridHolder, current);

        if (runeTrait == "Fire")
        {
            current.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0f, 0f, 1.0f);
            gridHolder[thisIndex + 1].GetComponent<SpriteRenderer>().color = isRed;
            gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color = isRed;
            for (int i = 0; i < 9; i++)
            {
                gridHolder[i].GetComponent<RunePlacement>().runeTrait = null;
            }
        }
        else if (runeTrait == "Water")
        {
            current.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1.0f, 1.0f);
            gridHolder[thisIndex + 3].GetComponent<SpriteRenderer>().color = isBlue;
            gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color = isBlue;
            for (int i = 0; i < 9; i++)
            {
                gridHolder[i].GetComponent<RunePlacement>().runeTrait = null;
            }
        }
        else if (runeTrait == "Air")
        {
            current.GetComponent<SpriteRenderer>().color = new Color(0f, 1.0f, 0f, 1.0f);
            gridHolder[thisIndex + 4].GetComponent<SpriteRenderer>().color = isGreen;
            gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color = isGreen;
            for (int i = 0; i < 9; i++)
            {
                gridHolder[i].GetComponent<RunePlacement>().runeTrait = null;
            }
        }
        else if (runeTrait == "Earth")
        {
            current.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.92f, 0.016f, 1.0f);
            gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color = isYellow;
            gridHolder[thisIndex + 7].GetComponent<SpriteRenderer>().color = isYellow;
            for (int i = 0; i < 9; i++)
            {
                gridHolder[i].GetComponent<RunePlacement>().runeTrait = null;
            }
        }
        else if (runeTrait == "Charm")
        {
            current.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            gridHolder[thisIndex + 2].GetComponent<SpriteRenderer>().color = isPink;
            gridHolder[thisIndex + 6].GetComponent<SpriteRenderer>().color = isPink;
            for (int i = 0; i < 9; i++)
            {
                gridHolder[i].GetComponent<RunePlacement>().runeTrait = null;
            }
        }
        else if (runeTrait == "Flux")
        {
            current.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1.0f);
            for (int i = 0; i < 9; i++)
            {
                gridHolder[i].GetComponent<RunePlacement>().runeTrait = null;
            }
        }
    }

    void OnMouseExit()
    {
        current = this.gameObject;
        GameObject[] gridHolder = GameObject.FindGameObjectsWithTag("gridElement");
        int thisIndex = System.Array.IndexOf(gridHolder, current);
        for (int i = 0; i < 9; i++)
        {
           if (gridHolder[i].GetComponent<SpriteRenderer>().color != isRed && gridHolder[i].GetComponent<SpriteRenderer>().color != isBlue && gridHolder[i].GetComponent<SpriteRenderer>().color != isGreen && gridHolder[i].GetComponent<SpriteRenderer>().color != isYellow && gridHolder[i].GetComponent<SpriteRenderer>().color != isPink && gridHolder[i].GetComponent<SpriteRenderer>().color != isBlack)
            {
                gridHolder[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            }
        }

    }
}

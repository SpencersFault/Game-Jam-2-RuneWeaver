using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMaker : MonoBehaviour
{
    private int fire;
    private int water;
    private int air;
    private int earth;
    private int charm;
    private bool flux = false;

    private Color isRed = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Color isGreen = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    private Color isBlue = new Color(0.0f, 0.0f, 1.0f, 1.0f);
    private Color isPink = new Color(1.0f, 0.0f, 1.0f, 1.0f);
    private Color isYellow = new Color(1.0f, 0.92f, 0.016f, 1.0f);
    private Color isBlack = new Color(0.0f, 0.0f, 0.0f, 1.0f);

    private int[] colours = new int[5];

    private bool reverse;

    public List<GameObject> gridElements = new List<GameObject>();

    private void OnMouseDown()
    {
        colourCounter();
    }

    private void colourCounter()
    {

        var gridElements = GameObject.FindGameObjectsWithTag("gridElement");
        foreach (GameObject gridPiece in gridElements)
        {
            var gridSprite = gridPiece.GetComponent<SpriteRenderer>();
            if (gridSprite.color == isRed)
            {
                colours[0] = colours[0] + 1;
            }
            if (gridSprite.color == isBlue)
            {
                colours[1] = colours[1] + 1;
            }
            if (gridSprite.color == isGreen)
            {
                colours[2] = colours[2] + 1;
            }
            if (gridSprite.color == isYellow)
            {
                colours[3] = colours[3] + 1;
            }
            if (gridSprite.color == isPink)
            {
                colours[4] = colours[4] + 1;
            }
            if (gridSprite.color == isBlack)
            {
                reverse = true;
            }
        }

        spellCaster(colours, reverse);
    }

    private void spellCaster(int[] colours, bool reverse)
    {
        fire = colours[0]; //red
        water = colours[1]; //blue
        air = colours[2]; //green
        earth = colours[3]; //yellow
        charm = colours[4]; //pink
        flux = reverse; //black

        if (flux == false)
        {
            if (fire > 0 && water == 0 && air == 0 && earth == 0 && charm == 0)
            {
                Cast("Fireball");
            }
            else if(fire == 0 && water > 0 && air == 0 && earth == 0 && charm == 0)
            {
                Cast("Drench");
            }
            else if (fire == 0 && water == 0 && air > 0 && earth == 0 && charm == 0)
            {
                Cast("Gust");
            }
            else if (fire == 0 && water == 0 && air == 0 && earth > 0 && charm == 0)
            {
                Cast("Quake");
            }
            else if (fire == 0 && water == 0 && air == 0 && earth == 0 && charm > 0)
            {
                Cast("Flirt");
            }
        }
        else if (flux == true)
        {
            if (fire > 0 && water == 0 && air == 0 && earth == 0 && charm == 0)
            {
                Cast("Freeze");
            }
            else if (fire == 0 && water > 0 && air == 0 && earth == 0 && charm == 0)
            {
                Cast("Parch");
            }
            else if (fire == 0 && water == 0 && air > 0 && earth == 0 && charm == 0)
            {
                Cast("Vacuum");
            }
            else if (fire == 0 && water == 0 && air == 0 && earth > 0 && charm == 0)
            {
                Cast("Stabilize");
            }
            else if (fire == 0 && water == 0 && air == 0 && earth == 0 && charm > 0)
            {
                Cast("Disgust");
            }
        }

    }

    private void Cast(string spell)
    {
        Debug.Log("You cast" + spell);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

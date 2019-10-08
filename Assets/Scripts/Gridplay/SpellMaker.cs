using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Color isWhite = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    private int[] colours = new int[5];

    private bool reverse;

    private GameObject[] gridHolder = new GameObject[9];

    private GameObject enemy;
    private GameObject ActionDisplay;
    
    public void OnMouseDown()
    {
        colourCounter();
    }

    private void colourCounter()
    {
        GameObject[] gridHolder = GameObject.FindGameObjectsWithTag("gridElement");
        for (int i = 0; i < 9; i++)
        {
            var gridSprite = gridHolder[i].GetComponent<SpriteRenderer>().color;
            if (gridSprite == isRed)
            {
                colours[0] = colours[0] + 1;
            }
            if (gridSprite == isBlue)
            {
                colours[1] = colours[1] + 1;
            }
            if (gridSprite == isGreen)
            {
                colours[2] = colours[2] + 1;
            }
            if (gridSprite == isYellow)
            {
                colours[3] = colours[3] + 1;
            }
            if (gridSprite == isPink)
            {
                colours[4] = colours[4] + 1;
            }
            if (gridSprite == isBlack)
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

        // when flux is INACTIVE
        if (flux == false)
        {
            if (fire > 0)
            {


                if (water > 0 && water < 4)
                {
                    Cast("Scald");
                }
                if (air > 0 && air < 4)
                {
                    Cast("Heat Wave");
                }
                if (earth > 0 && earth < 4)
                {
                    Cast("Blast");
                }
                if (charm > 0 && charm < 4)
                {
                    Cast("Warm Fuzzies");
                }
                if (fire > 0 && water == 0 && air == 0 && earth == 0 && charm == 0)
                {
                    if (fire == 3)
                    {
                        Cast("Fireball");
                    }
                    else if (fire == 6)
                    {
                        Cast("Fire Blast");
                    }
                }
            }

            if (water > 0)
            {
                if (air > 0 && air < 4)
                {
                    Cast("Rainstorm");
                }
                if (earth > 0 && earth < 4)
                {
                    Cast("Mud");
                }
                if (charm > 0 && charm < 4)
                {
                    Cast("Perfume");
                }                
                if (fire == 0 && water > 0 && air == 0 && earth == 0 && charm == 0)
                {
                    if (water == 3)
                    {
                        Cast("Drench");
                    }
                    if (water == 6)
                    {
                        Cast("Soak");
                    }
                    if (water == 9)
                    {
                        Cast("Deluge");
                    }
                }
                if (air > 0)
                {
                    if (earth > 0 && earth < 4)
                    {
                        Cast("Sandstorm");
                    }
                    if (fire == 0 && water == 0 && air > 0 && earth == 0 && charm == 0)
                    {
                        if (air == 3)
                        {
                            Cast("Gust");
                        }
                        if (air == 6)
                        {
                            Cast("Whirlwind");
                        }
                    }
                }
                if (earth > 0)
                {
                    if (charm > 0 && charm < 4)
                    {
                        Cast("Salve");
                    }
                    if (fire == 0 && water == 0 && air == 0 && earth > 0 && charm == 0)
                    {
                        if (earth == 3)
                        {
                            Cast("Quake");
                        }
                    }
                }
                if (fire == 0 && water == 0 && air == 0 && earth == 0 && charm > 0)
                {
                    if (charm == 3)
                    {
                        Cast("Flirt");
                    }
                    if (charm == 6)
                    {
                        Cast("Infatuate");
                    }
                }

            }
        }
        // when flux is ACTIVE
        // fire -> cold
        // water -> dry
        // air -> gravity
        // earth -> death (drain)
        // charm -> repel
        else if (flux == true)
        {


            if (fire > 0)
            {
                if (water > 0 && water < 4)
                {
                    Cast("Snowfall");
                }
                if (air > 0 && air < 4)
                {
                    Cast("Cold Front");
                }
                if (earth > 0 && earth < 4)
                {
                    Cast("Tundra");
                }
                if (charm > 0 && charm < 4)
                {
                    Cast("Cold Shoulder");
                }
                if (fire > 0 && water == 0 && air == 0 && earth == 0 && charm == 0)
                {
                    if (fire == 3)
                    {
                        Cast("Freeze");
                    }
                    else if (fire == 6)
                    {
                        Cast("Subzero");
                    }
                }

            }

            if (water > 0)
            {


                if (air > 0 && air < 4)
                {
                    Cast("Hailstorm");
                }
                if (earth > 0 && earth < 4)
                {
                    Cast("Swamp");
                }
                if (charm > 0 && charm < 4)
                {
                    Cast("Stench");
                }
                if (fire == 0 && water > 0 && air == 0 && earth == 0 && charm == 0)
                {
                    if (water == 3)
                    {
                        Cast("Parch");
                    }
                    if (water == 6)
                    {
                        Cast("Evaporate");
                    }
                    if (water == 9)
                    {
                        Cast("Drought");
                    }
                }
                if (air > 0)
                {
                    if (earth > 0 && earth < 4)
                    {
                        Cast("Pale Wind");
                    }
                    if (fire == 0 && water == 0 && air > 0 && earth == 0 && charm == 0)
                    {
                        if (air == 3)
                        {
                            Cast("Slow");
                        }
                        if (air == 6)
                        {
                            Cast("Crush");
                        }
                    }
                }
                if (earth > 0)
                {
                    if (charm > 0 && charm < 4)
                    {
                        Cast("Poison");
                    }
                    if (fire == 0 && water == 0 && air == 0 && earth > 0 && charm == 0)
                    {
                        if (earth == 3)
                        {
                            Cast("Drain");
                        }
                    }
                }
                if (fire == 0 && water == 0 && air == 0 && earth == 0 && charm > 0)
                {
                    if (charm == 3)
                    {
                        Cast("Repel");
                    }
                    if (charm == 6)
                    {
                        Cast("Disgust");
                    }
                }

            }
        }

    }

    private void Cast(string spell)
    {
        Debug.Log("You cast " + spell + "!");
        GameObject[] gridHolder = GameObject.FindGameObjectsWithTag("gridElement");
        for (int i = 0; i < 9; i++)
        {
            gridHolder[i].GetComponent<SpriteRenderer>().color = isWhite;
        }
        for (int i = 0; i < 5; i++)
        {
            colours[i] = 0;
        }
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

﻿using System.Collections;
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

        if (flux == false)
        {
            if (fire > 0 && water == 0 && air == 0 && earth == 0 && charm == 0)
            {
                Cast("Fireball");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 5f;
                Debug.Log("Enemy Slime takes 5 damage");
                

            }
            else if(fire == 0 && water > 0 && air == 0 && earth == 0 && charm == 0)
            {
                Cast("Drench");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 1f;
                Debug.Log("Enemy Slime takes 1 damage");
            }
            else if (fire == 0 && water == 0 && air > 0 && earth == 0 && charm == 0)
            {
                Cast("Gust");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 3f;
                Debug.Log("Enemy Slime takes 3 damage");
            }
            else if (fire == 0 && water == 0 && air == 0 && earth > 0 && charm == 0)
            {
                Cast("Quake");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 10f;
                Debug.Log("Enemy Slime takes 10 damage");
            }
            else if (fire == 0 && water == 0 && air == 0 && earth == 0 && charm > 0)
            {
                Cast("Flirt");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentATK -= 2f;
                Debug.Log("Enemy Slime is weakened");
            }
        }
        else if (flux == true)
        {
            if (fire > 0 && water == 0 && air == 0 && earth == 0 && charm == 0)
            {
                Cast("Freeze");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 10f;
                Debug.Log("Enemy Slime takes 10 damage");
            }
            else if (fire == 0 && water > 0 && air == 0 && earth == 0 && charm == 0)
            {
                Cast("Parch");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 50f;
                Debug.Log("Enemy Slime takes 50 damage");
            }
            else if (fire == 0 && water == 0 && air > 0 && earth == 0 && charm == 0)
            {
                Cast("Vacuum");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 100f;
                Debug.Log("Enemy Slime is captured");
            }
            else if (fire == 0 && water == 0 && air == 0 && earth > 0 && charm == 0)
            {
                Cast("Stabilize");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP += 10f;
                Debug.Log("Enemy Slime heals by 10");
            }
            else if (fire == 0 && water == 0 && air == 0 && earth == 0 && charm > 0)
            {
                Cast("Disgust");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 100f;
                Debug.Log("Enemy Slime runs away");
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

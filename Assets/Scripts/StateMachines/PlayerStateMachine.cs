﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour
{
    public Player player;
    private BattleStateMachine BSM;
    
    

    public enum turnState
    {
        alive,
        dead
    }
    public turnState currentState;
    //for the health bar
    
    //this gameobject
    private Vector2 startPosition;
    private bool alive = true;
    private PlayerStats stats;
    public GameObject playerDisplay;
    void Start()
    {
        //create panel, fill in info
        createPlayerDisplay();

        currentState = turnState.alive;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log (currentState);
        switch (currentState)
        {

            case (turnState.dead):
                if (!alive)
                {
                    return;
                }
                else
                {
                    //change tags
                    this.gameObject.tag = "Dead";
                    BSM.PlayerInBattle.Remove(this.gameObject);
                    //not attackable by enemy

                    //remove item from performlist
                    if (BSM.PlayerInBattle.Count > 0)
                    {
                        for (int i = 0; i < BSM.PerformList.Count; i++)
                        {
                            if (BSM.PerformList[i].AttacksGameObject == this.gameObject)
                            { BSM.PerformList.Remove(BSM.PerformList[i]); }
                            if (BSM.PerformList[i].AttackersTarget == this.gameObject)
                            {
                                BSM.PerformList[i].AttackersTarget = BSM.PlayerInBattle[Random.Range(0, BSM.PlayerInBattle.Count)];
                            }
                        }
                        //not manageable
                        BSM.battleState = BattleStateMachine.performAction.CheckAlive;
                        alive = false;
                    }
                }
                break;
        }

    }
   
    public void TakeDamage(float getDamageAmount)
    {
        player.currentHP -= getDamageAmount;
        
        if(player.currentHP <= 0)
        {
            player.currentHP = 0;
            currentState = turnState.dead;
        }
        UpdatePlayerDisplay();
    }

    void createPlayerDisplay()
    {
        playerDisplay = Instantiate(playerDisplay) as GameObject;
        stats = playerDisplay.GetComponent<PlayerStats>();
        stats.playerName.text = player.playername;
        stats.playerHP.text = "HP: " + player.currentHP;
    }


    void UpdatePlayerDisplay()
    {
        print(player.currentHP);
        stats.playerHP.text = "HP: " + player.currentHP;
        if (player.currentHP <= player.baseHP)
        {
            stats.playerHP = GameObject.Find("PlayerHP").GetComponent<Text>();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleStateMachine : MonoBehaviour
{
    public enum performAction
    {
        Wait,
        TakeAction,
        PerformAction,
        CheckAlive,
        Win,
        Lose
    }

    public performAction battleState;

    public List<HandleTurn> PerformList = new List<HandleTurn>();

    public List<GameObject> PlayerInBattle = new List<GameObject>();
    public List<GameObject> EnemyInBattle = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        battleState = performAction.Wait;
        EnemyInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        PlayerInBattle.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }

    // Update is called once per frame
    public void Update()
    {
        switch (battleState)
        {
            case (performAction.Wait):
                if(PerformList.Count > 0)
                {
                    battleState = performAction.TakeAction;
                }
                break;

            case (performAction.TakeAction):
                GameObject performer = GameObject.Find(PerformList[0].Attacker);
                if (PerformList[0].Type == "Enemy")
                {
                    EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                    
                    for (int i = 0; i < PlayerInBattle.Count; i++)
                    {
                        if (PerformList[0].AttackersTarget == PlayerInBattle[i])
                        {
                            ESM.PlayerToAttack = PerformList[0].AttackersTarget;
                            ESM.currentState = EnemyStateMachine.turnState.action;
                        }
                        else
                        {
                            PerformList[0].AttackersTarget = PlayerInBattle[Random.Range(0, PlayerInBattle.Count)];
                            ESM.PlayerToAttack = PerformList[0].AttackersTarget;
                            ESM.currentState = EnemyStateMachine.turnState.action;
                        }
                    }
                }
                if (PerformList[0].Type == "Player")
                {

                }
                battleState = performAction.PerformAction;
                break;

            case (performAction.PerformAction):
                break;

            case (performAction.CheckAlive):
                if (PlayerInBattle.Count < 1)
                {
                    battleState = performAction.Lose;
                    //lose game
                }
                else if (EnemyInBattle.Count < 1)
                {
                    battleState = performAction.Win;
                }
                else
                {
                    //call function
                }
                break;

            case (performAction.Win):
                {
                    Debug.Log("Victory!");
                }
                break;

            case (performAction.Lose):
                {
                    Debug.Log("Game Over");
                }
                break;
        }
    }

    public void CollectActions(HandleTurn input)
    {
        PerformList.Add(input);
    }
}

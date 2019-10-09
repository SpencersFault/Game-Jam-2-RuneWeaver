using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Text victoryText;
    public Text loseText;
    public GameObject rematchButton;
    public GameObject returnButton;
    public GameObject resultPanel;
    public GameObject castButton;
    public GameObject resetButton;
    public GameObject actionDisplay;
    public GameObject actionBar;
    
    // Start is called before the first frame update
    void Start()
    {
        battleState = performAction.Wait;
        EnemyInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        PlayerInBattle.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        victoryText.text = "";
        loseText.text = "";
        rematchButton.SetActive(false);
        returnButton.SetActive(false);
        resultPanel.SetActive(false);
        castButton.SetActive(true);
        resetButton.SetActive(true);
        actionDisplay.SetActive(true);
        actionBar.SetActive(true);
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
                
                break;

            case (performAction.Win):
                {
                    Debug.Log("Victory!");
                    for (int i = 0; i < PlayerInBattle.Count; i++)
                    {
                        PlayerInBattle[i].GetComponent<PlayerStateMachine>().currentState = PlayerStateMachine.turnState.alive;
                    }
                    victoryText.text = "Victory!";
                    rematchButton.SetActive(true);
                    returnButton.SetActive(true);
                    resultPanel.SetActive(true);
                    castButton.SetActive(false);
                    resetButton.SetActive(false);
                    actionDisplay.SetActive(false);
                    actionBar.SetActive(false);

                }
                break;

            case (performAction.Lose):
                {
                    for (int i = 0; i < PlayerInBattle.Count; i++)
                    {
                        EnemyInBattle[i].GetComponent<EnemyStateMachine>().currentState = EnemyStateMachine.turnState.waiting;
                    }
                    loseText.text = "Game Over";
                    rematchButton.SetActive(true);
                    returnButton.SetActive(true);
                    resultPanel.SetActive(true);
                    castButton.SetActive(false);
                    resetButton.SetActive(false);
                    actionDisplay.SetActive(false);
                    actionBar.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateMachine : MonoBehaviour
{
    public BattleStateMachine BSM;
    public EnemySlime enemy;

    public enum turnState
    {
        processing,
        chooseAction,
        waiting,
        action,
        dead
    }
    public turnState currentState;
    //for the health bar

    private float currentCooldown = 0f;
    private float maxCooldown = 5f;
    public Image progressbar;
    public Text enemyHealth;

    //this gameobject
    private Vector2 startPosition;
    //timeforaction 
    private bool actionStarted = false;
    public GameObject PlayerToAttack;
    private EnemyStats stats;
    public GameObject enemyDisplay;

    private bool alive = true;
    void Start()
    {
        currentState = turnState.processing;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        startPosition = transform.position;
    }

    void Update()
    {
        //Debug.Log (currentState);
        switch (currentState)
        {
            case (turnState.processing):
                UpgradeProgressBar();
    
            break;

            case (turnState.chooseAction):
                ChooseAction();
                currentState = turnState.waiting;
                break;

            case (turnState.waiting):
                //idle state
                break;


            case (turnState.action):
                StartCoroutine(TimeForAction());
                break;

            case (turnState.dead):
                if (!alive)
                {
                    return;
                }
                else
                {
                    //change tag of enemy
                    this.gameObject.tag = "DeadEnemy";
                    //not attackable
                    BSM.EnemyInBattle.Remove(this.gameObject);
                    //dead animation
                    //this.gameObject.GetComponent<SpriteRenderer>().
                    alive = false;
                }
                break;
        }
    }

    void UpgradeProgressBar()
    {
        currentCooldown = currentCooldown + Time.deltaTime;
        float calc_cooldown = currentCooldown / maxCooldown;
        progressbar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), progressbar.transform.localScale.y, progressbar.transform.localScale.z);
        if (currentCooldown >= maxCooldown)
        {
            currentState = turnState.chooseAction;
        }
    }

    void ChooseAction()
    {
        HandleTurn myAttack = new HandleTurn();
        myAttack.Attacker = enemy.enemyname; 
        myAttack.Type = "Enemy";
        myAttack.AttacksGameObject = this.gameObject;
        myAttack.AttackersTarget = BSM.PlayerInBattle[Random.Range(0, BSM.PlayerInBattle.Count)]; //selecting player?

        int num = Random.Range(0, enemy.attacks.Count);
        myAttack.choosenAttack = enemy.attacks[num];
        Debug.Log(this.gameObject.name + " used " + myAttack.choosenAttack.attackName + " dealing " + myAttack.choosenAttack.attackDamage + " damage ");

        BSM.CollectActions (myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        //animate the enemy near the player

        {
            yield return null;
        }
        //wait a bit
        yield return new WaitForSeconds(0.5f);
        //do damage
        DoDamage();
        //animate back to startposition
        Vector2 firstPosition = startPosition;
        {
            yield return null;
        }
        //remove this performer from the list in BSM
        BSM.PerformList.RemoveAt(0);
        //reset BSM -> Wait
        BSM.battleState = BattleStateMachine.performAction.Wait;
        //end coroutine
        actionStarted = false;
        //reset this enemy state
        currentCooldown = 1f;
        currentState = turnState.processing;
    }

    void DoDamage()
    {
        float calc_damage = enemy.currentATK + BSM.PerformList [0].choosenAttack.attackDamage;
        PlayerToAttack.GetComponent<PlayerStateMachine>().TakeDamage(calc_damage);
    }
    public void TakeDamage(float getDamageAmount)
    {
        enemy.currentHP -= getDamageAmount;
        
        if (enemy.currentHP <= 0)
        {
            currentState = turnState.dead;
            Debug.Log("Victory!");
        }

    }
    public void createPlayerDisplay()
    {
        enemyDisplay = Instantiate(enemyDisplay) as GameObject;
        stats = enemyDisplay.GetComponent<EnemyStats>();
        stats.enemyName.text = enemy.enemyname;
        stats.enemyHP.text = "HP: " + enemy.currentHP;
        

    }


    public void UpdateEnemyDisplay()
    {
        stats.enemyHP.text = "HP: " + enemy.currentHP;

    }
}

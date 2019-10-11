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

    private GameObject fireFX;
    private GameObject waterFX;
    private GameObject airFX;
    private GameObject earthFX;
    private GameObject charmFX;
    private GameObject iceFX;
    private GameObject dryFX;
    private GameObject grossFX;
    

    // Start is called before the first frame update
    void Start()
    {
        fireFX = GameObject.FindGameObjectWithTag("fire_enemy");
        waterFX = GameObject.FindGameObjectWithTag("water_shower");
        airFX = GameObject.FindGameObjectWithTag("air_wand");
        earthFX = GameObject.FindGameObjectWithTag("earth_enemy");
        charmFX = GameObject.FindGameObjectWithTag("charm_enemy");
        iceFX = GameObject.FindGameObjectWithTag("flux_hailstorm");
        dryFX = GameObject.FindGameObjectWithTag("flux_evaporate");
        grossFX = GameObject.FindGameObjectWithTag("flux_stench");

    }

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
                    fireFX.GetComponent<ParticleSystem>().Play();
                    waterFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 20f;
                    Debug.Log("Enemy Slime takes 20 damage");
                }
                if (air > 0 && air < 4)
                {
                    Cast("Heat Wave");
                    fireFX.GetComponent<ParticleSystem>().Play();
                    airFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 30f;
                    Debug.Log("Enemy Slime takes 30 damage");
                }
                if (earth > 0 && earth < 4)
                {
                    Cast("Blast");
                    fireFX.GetComponent<ParticleSystem>().Play();
                    earthFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 60f;
                    Debug.Log("Enemy Slime takes 60 damage");
                }
                if (charm > 0 && charm < 4)
                {
                    Cast("Warm Fuzzies");
                    fireFX.GetComponent<ParticleSystem>().Play();
                    charmFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP += 1f;
                    Debug.Log("Enemy Slime heals for 1");
                }
                if (fire > 0 && water == 0 && air == 0 && earth == 0 && charm == 0)
                {
                    if (fire == 3)
                    {
                        Cast("Fireball");
                        fireFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 50f;
                        Debug.Log("Enemy Slime takes 50 damage");
                    }
                    else if (fire == 6)
                    {
                        Cast("Fire Blast");
                        fireFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 75f;
                        Debug.Log("Enemy Slime takes 75 damage");
                    }
                }
            }
            if (water > 0)
            {
                if (air > 0 && air < 4)
                {
                    Cast("Rainstorm");
                    waterFX.GetComponent<ParticleSystem>().Play();
                    airFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 5f;
                    Debug.Log("Enemy Slime takes 5 damage");
                }
                if (earth > 0 && earth < 4)
                {
                    Cast("Mud");
                    waterFX.GetComponent<ParticleSystem>().Play();
                    earthFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 10f;
                    Debug.Log("Enemy Slime takes 5 damage");
                }
                if (charm > 0 && charm < 4)
                {
                    Cast("Perfume");
                    waterFX.GetComponent<ParticleSystem>().Play();
                    charmFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentATK -= 5f;
                    Debug.Log("Enemy Slime is weakened");
                }
                if (fire == 0 && water > 0 && air == 0 && earth == 0 && charm == 0)
                {
                    if (water == 3)
                    {
                        Cast("Drench");
                        waterFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 5f;
                        Debug.Log("Enemy Slime takes 5 damage");
                    }
                    if (water == 6)
                    {
                        Cast("Soak");
                        waterFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 10f;
                        Debug.Log("Enemy Slime takes 10 damage");
                    }
                    if (water == 9)
                    {
                        Cast("Deluge");
                        waterFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 15f;
                        Debug.Log("Enemy Slime takes 15 damage");
                    }
                }
            }
            if (air > 0)
            {
                if (earth > 0 && earth < 4)
                {
                    Cast("Sandstorm");
                    airFX.GetComponent<ParticleSystem>().Play();
                    earthFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 25f;
                    Debug.Log("Enemy Slime takes 25 damage");
                }
                if (fire == 0 && water == 0 && air > 0 && earth == 0 && charm == 0)
                {
                    if (air == 3)
                    {
                        Cast("Gust");
                        airFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 20f;
                        Debug.Log("Enemy Slime takes 20 damage");
                    }
                    if (air == 6)
                    {
                        Cast("Whirlwind");
                        airFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 25f;
                        Debug.Log("Enemy Slime takes 25 damage");
                    }
                }
            }
            if (earth > 0)
            {
                if (charm > 0 && charm < 4)
                {
                    Cast("Salve");
                    earthFX.GetComponent<ParticleSystem>().Play();
                    charmFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<PlayerStateMachine>().player.currentHP += 25f;
                    Debug.Log("You heal for 25 damage");
                }
                if (fire == 0 && water == 0 && air == 0 && earth > 0 && charm == 0)
                {
                    if (earth == 3)
                    {
                        Cast("Quake");
                        earthFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 30f;
                        Debug.Log("Enemy Slime takes 30 damage");
                    }
                }
            }
            if (charm > 0)
            {
                if (fire == 0 && water == 0 && air == 0 && earth == 0 && charm > 0)
                {
                    if (charm == 3)
                    {
                        Cast("Flirt");
                        charmFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentATK -= 3f;
                        Debug.Log("Enemy Slime is weakened");
                    }
                    if (charm == 6)
                    {
                        Cast("Infatuate");
                        charmFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentATK -= 10f;
                        Debug.Log("Enemy Slime is weakened");
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
        if (flux == true)
        {


            if (fire > 0)
            {
                if (water > 0 && water < 4)
                {
                    Cast("Snowfall");
                    iceFX.GetComponent<ParticleSystem>().Play();
                    dryFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 10f;
                    Debug.Log("Enemy Slime takes 10 damage");
                }
                if (air > 0 && air < 4)
                {
                    Cast("Cold Front");
                    iceFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 30f;
                    Debug.Log("Enemy Slime takes 30 damage");
                }
                if (earth > 0 && earth < 4)
                {
                    Cast("Tundra");
                    iceFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 50f;
                    Debug.Log("Enemy Slime takes 50 damage");
                }
                if (charm > 0 && charm < 4)
                {
                    Cast("Cold Shoulder");
                    iceFX.GetComponent<ParticleSystem>().Play();
                    grossFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentATK += 5f;
                    Debug.Log("Enemy Slime is angered");
                }
                if (fire > 0 && water == 0 && air == 0 && earth == 0 && charm == 0)
                {
                    if (fire == 3)
                    {
                        Cast("Freeze");
                        iceFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 30f;
                        Debug.Log("Enemy Slime takes 30 damage");
                    }
                    else if (fire == 6)
                    {
                        Cast("Subzero");
                        iceFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 50f;
                        Debug.Log("Enemy Slime takes 50 damage");
                    }
                }

            }

            if (water > 0)
            {


                if (air > 0 && air < 4)
                {
                    Cast("Hailstorm");
                    dryFX.GetComponent<ParticleSystem>().Play();
                    iceFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 25f;
                    Debug.Log("Enemy Slime takes 25 damage");
                }
                if (earth > 0 && earth < 4)
                {
                    Cast("Swamp");
                    dryFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP += 5f;
                    Debug.Log("Enemy Slime heals for 5");
                }
                if (charm > 0 && charm < 4)
                {
                    Cast("Stench");
                    dryFX.GetComponent<ParticleSystem>().Play();
                    grossFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentATK -= 1f;
                    Debug.Log("Enemy Slime is hesitant");
                }
                if (fire == 0 && water > 0 && air == 0 && earth == 0 && charm == 0)
                {
                    if (water == 3)
                    {
                        Cast("Parch");
                        dryFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 100f;
                        Debug.Log("Enemy Slime takes 100 damage");
                    }
                    if (water == 6)
                    {
                        Cast("Evaporate");
                        dryFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 200f;
                        Debug.Log("Enemy Slime takes 200 damage");
                    }
                    if (water == 9)
                    {
                        Cast("Drought");
                        dryFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 1000f;
                        Debug.Log("Enemy Slime takes 1000 damage");
                    }
                }
            }
            if (air > 0)
            {
                if (earth > 0 && earth < 4)
                {
                    Cast("Pale Wind");
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 20f;
                    Debug.Log("Enemy Slime takes 20 damage");
                }
                if (fire == 0 && water == 0 && air > 0 && earth == 0 && charm == 0)
                {
                    if (air == 3)
                    {
                        Cast("Slow");
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 5f;
                        Debug.Log("Enemy Slime takes 5 damage");
                    }
                    if (air == 6)
                    {
                        Cast("Crush");
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 60f;
                        Debug.Log("Enemy Slime takes 60 damage");
                    }
                }
            }
            if (earth > 0)
            {
                if (charm > 0 && charm < 4)
                {
                    Cast("Poison");
                    grossFX.GetComponent<ParticleSystem>().Play();
                    enemy = GameObject.FindGameObjectWithTag("Enemy");
                    enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 5f;
                    Debug.Log("Enemy Slime takes 5 damage");
                }
                if (fire == 0 && water == 0 && air == 0 && earth > 0 && charm == 0)
                {
                    if (earth == 3)
                    {
                        Cast("Drain");
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 10f;
                        enemy.GetComponent<PlayerStateMachine>().player.currentHP += 10f;
                        Debug.Log("Enemy Slime is drained for 5 damage");
                    }
                }
            }
            if (charm > 0)
            {
                if (fire == 0 && water == 0 && air == 0 && earth == 0 && charm > 0)
                {
                    if (charm == 3)
                    {
                        Cast("Repel");
                        grossFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentATK -= 5f;
                        Debug.Log("Enemy Slime takes hurts you for less");
                    }
                    if (charm == 6)
                    {
                        Cast("Disgust");
                        grossFX.GetComponent<ParticleSystem>().Play();
                        enemy = GameObject.FindGameObjectWithTag("Enemy");
                        enemy.GetComponent<EnemyStateMachine>().enemy.currentHP -= 1000f;
                        Debug.Log("Enemy Slime flees");
                    }
                }
            }

        }

    }

    

    private void Cast(string spell)
    {       
        GameObject ActionDisplay = GameObject.FindGameObjectWithTag("Action");
        ActionDisplay.GetComponent<Text>().text = "You cast " + spell + "!";
        //yield return new WaitForSeconds(5f)
        


        GameObject[] gridHolder = GameObject.FindGameObjectsWithTag("gridElement");
        for (int i = 0; i < 9; i++)
        {
            gridHolder[i].GetComponent<SpriteRenderer>().color = isWhite;
        }
        for (int i = 0; i < 5; i++)
        {
            colours[i] = 0;
        }
			reverse = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

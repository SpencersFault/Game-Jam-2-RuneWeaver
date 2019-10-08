using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySlime
{

    
        public string enemyname;

        public enum Type
        {
            earth,
            fire,
            water,
            air
        }

        public enum Rarity
        {
            common,
            uncommon,
            rare,
            superrare
        }

        public Type EnemyType;
        public Rarity rarity;

        public float baseHP;
        public float currentHP;

        public float baseATK;
        public float currentATK;
        public float baseDEF;
        public float currentDEF;

    public List<baseAttack> attacks = new List<baseAttack>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public string playername;
   
    public float baseHP;
    public float currentHP;

    public float baseATK;

    public List<baseAttack> attacks = new List<baseAttack>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}

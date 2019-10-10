using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStart : MonoBehaviour
{
    public string TargetScene;

    void OnCollisionEnter2D()
    {
        SceneManager.LoadScene(TargetScene);
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

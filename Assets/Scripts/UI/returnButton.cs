using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnButton : MonoBehaviour
{
    public string TargetScene;

    public GameObject rematchButton;
    public GameObject rereturnButton;
    public GameObject resultPanel;
    public GameObject PlayerDisplay;
    public GameObject EnemyDisplay;
    public Text victoryText;
    public Text loseText;

    bool sceneload = false;

    public void OnMouseUp()
    {
        SceneManager.LoadScene(TargetScene);
        sceneload = true;
        Reset();
    }

    private void Reset()
    {
        if (sceneload == true)
        rematchButton.SetActive(false);
        rereturnButton.SetActive(false);
        resultPanel.SetActive(false);
        PlayerDisplay.SetActive(false);
        EnemyDisplay.SetActive(false);
        victoryText.text = "";
        loseText.text = "";
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

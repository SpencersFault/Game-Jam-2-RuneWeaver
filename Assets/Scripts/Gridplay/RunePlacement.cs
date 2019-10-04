using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePlacement : MonoBehaviour
{

    public List<GameObject> grid = new List<GameObject>();
    private GameObject[] gridHolder = new GameObject[9];
    public string runeTrait;

    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log(GameObject.FindGameObjectsWithTag("gridElement"));
        GameObject[] gridPlaceholder = GameObject.FindGameObjectsWithTag("gridElement");
        foreach (GameObject ele in gridPlaceholder)
        {
            grid.Add(ele);
            Debug.Log("Yeet");
        }*/


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onMouseOver()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("gridElement"));
        GameObject[] gridPlaceholder = GameObject.FindGameObjectsWithTag("gridElement");
        foreach (GameObject ele in gridPlaceholder)
        {
            grid.Add(ele);
            Debug.Log("Yeet");
        }
    }

    void onMouseExit()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGrid : MonoBehaviour
{
    private Color isWhite = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    private GameObject[] gridHolder = new GameObject[9];

    public void Reset()
    {
        GameObject[] gridHolder = GameObject.FindGameObjectsWithTag("gridElement");

        for (int i = 0; i < 9; i++)
        {
            gridHolder[i].GetComponent<SpriteRenderer>().color = isWhite;
        }
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

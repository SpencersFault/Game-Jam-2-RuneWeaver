using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastConfirm : MonoBehaviour
{
    private bool castSpell = false;
    public string runetrait;
    public SpellMaker spellMaker;

    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        castSpell = true;
        Debug.Log("Spell cast");
    }
    // Start is called before the first frame update
    private void OnMouseUp()
    {
        castSpell = false;
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

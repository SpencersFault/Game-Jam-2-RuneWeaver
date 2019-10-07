using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatGrid : MonoBehaviour
{

    public int dimensions;
    private int vertical;
    private int horizontal;
    public Sprite sprite;
    public float[,] runeSheet;
    int columns, rows;

    Collider thisCollider;

    // Start is called before the first frame update
    void Start()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
        columns = dimensions;
        rows = dimensions;
        runeSheet = new float[columns, rows];
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                runeSheet[i, j] = (1.0f);
                colourRunes(i, j, runeSheet[i, j]);

            }
        }
    }

    private void colourRunes(int x, int y, float value)
    {
        GameObject runeElement = new GameObject("X: " + x + " Y: " + y);
        runeElement.transform.position = new Vector3(x - 1.25f,y - 1.25f);
        runeElement.tag = "gridElement";
        runeElement.AddComponent<RunePlacement>();
        var collider = runeElement.AddComponent<CircleCollider2D>();
        var icon = runeElement.AddComponent<SpriteRenderer>();
        collider.isTrigger = true;
        icon.sprite = sprite;
        icon.color = new Color(value, value, value);
            }
}

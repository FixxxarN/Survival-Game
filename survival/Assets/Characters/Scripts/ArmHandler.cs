using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmHandler : MonoBehaviour
{
    private Transform transform;
    private SpriteRenderer spriteRenderer;
    private Color32[] SkinColors;

    void Start()
    {
        SkinColors = new Color32[] {
            new Color32(254, 253, 253, 255),
            new Color32(245, 234, 223, 255),
            new Color32(235, 214, 193, 255),
            new Color32(220, 185, 149, 255),
            new Color32(206, 155, 105, 255),
            new Color32(190, 126, 62, 255),
            new Color32(160, 106, 52, 255),
            new Color32(131, 87, 43, 255),
            new Color32(101, 67, 33, 255),
            new Color32(86, 57, 28, 255),
            new Color32(71, 47, 23, 255),
            new Color32(57, 38, 19, 255)
        };

        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = SkinColors[PlayerHandler.SkinColor];
    }

    void Update()
    {
        transform.localPosition = GameObject.Find("Player").GetComponent<Transform>().localPosition + new Vector3(-0.0657f, 0.1607f, 0);
        RotateTowardsMousePosition();
    }

    private void RotateTowardsMousePosition()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(mouseOnScreen, positionOnScreen);

        if(mouseOnScreen.x < positionOnScreen.x)
        {
            transform.localScale = new Vector3(1, -1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

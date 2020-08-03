using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmHandler : MonoBehaviour
{
    private Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
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

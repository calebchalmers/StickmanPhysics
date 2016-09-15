using UnityEngine;
using System.Collections;

public class Stickman : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Color color = Random.ColorHSV(0f, 1f, 0.9f, 1f, 0.7f, 0.9f, 1f, 1f);

        var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach(var sr in spriteRenderers)
        {
            sr.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

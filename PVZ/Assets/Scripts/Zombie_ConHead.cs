using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_ConHead : Zombie
{
    private bool conChange = true;
    SpriteRenderer spriteRenderer;
    public Sprite spriteZombie;
    

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void UpdateChange()
    {
        if (HP <= 3 && conChange)
        {
            spriteRenderer.sprite = spriteZombie;
            conChange = false;
        }
    }

    void Update()
    {
        UpdateChange();
    }
}

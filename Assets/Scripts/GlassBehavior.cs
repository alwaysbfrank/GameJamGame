using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehavior : MonoBehaviour
{
    public Sprite destroyedSprite;

    private SpriteRenderer sr;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerRock"))
        {
            sr.sprite = destroyedSprite;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehavior : MonoBehaviour
{
    public Sprite destroyedSprite;

    private SpriteRenderer sr;

    public AudioSource audio;

    public ParticleSystem partSys;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerRock"))
        {
            partSys.Play();
            audio.Play();
            sr.sprite = destroyedSprite;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashControl : MonoBehaviour
{
    public ParticleSystem partSys;
    public AudioSource audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        partSys.transform.position = new Vector2(collision.transform.position.x, partSys.transform.position.y);
        partSys.Play();
        audio.Play();
    }
}

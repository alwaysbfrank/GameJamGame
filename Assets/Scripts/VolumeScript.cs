using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{
    [Range(0, 100)] public float hearingDistance;
    public GameObject player;
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        var distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer > hearingDistance)
        {
            _audio.volume = 0f;
            return;
        }

        _audio.volume = 1 - distanceToPlayer / hearingDistance;
    }
}

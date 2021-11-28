using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalDrop : MonoBehaviour
{
    public float cooldown;
    public GameObject prefab;
    void Start()
    {
        StartCoroutine(Coal());
    }

    IEnumerator Coal()
    {
        while (true)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(cooldown);
        }
    }
}

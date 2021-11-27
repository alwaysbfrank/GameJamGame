using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public int speed;
    public bool direction;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (direction) 
        {
            StartCoroutine(moveLeft(collision));
        }
        else
        {
            StartCoroutine(moveRight(collision));
        }
    }


    IEnumerator moveLeft(Collision2D collision)
    {
        Vector3 displacementVector = new Vector3(-1, 0, 0);
        collision.gameObject.transform.Translate(displacementVector * speed * Time.deltaTime);
        Debug.Log("Left");
        yield return new WaitForSeconds(1);
    }

    IEnumerator moveRight(Collision2D collision)
    {
        Vector3 displacementVector = new Vector3(1, 0, 0);
        collision.gameObject.transform.Translate(displacementVector * speed * Time.deltaTime);
        Debug.Log("Right");
        yield return new WaitForSeconds(1);
    }
}

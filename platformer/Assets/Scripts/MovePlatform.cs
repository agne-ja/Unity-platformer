using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject Player;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }

}

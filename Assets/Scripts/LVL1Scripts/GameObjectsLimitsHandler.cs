using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsLimitsHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet"|| collision.tag == "SmallAsteroid")
        {
            Destroy(collision.gameObject);
        }
    }
}

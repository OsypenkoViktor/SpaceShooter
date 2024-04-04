using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDestroyOnInvisible : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x<=-61)
        {
            Destroy(gameObject);
        }
    }
}

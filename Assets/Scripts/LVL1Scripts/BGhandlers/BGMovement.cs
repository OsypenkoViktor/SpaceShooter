using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    public GameObject BGprefab;
    public float speed = 5.0f;
    bool isCreatedNextBGprefab = false;

    void Update()
    {

        // Двигаем объект влево по оси X
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (gameObject.transform.position.x<=0 && isCreatedNextBGprefab==false)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x + GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y, transform.position.z);
            GameObject NewBGImage =  Instantiate(BGprefab, spawnPosition, Quaternion.identity);
            isCreatedNextBGprefab = true;
        }
    }
}
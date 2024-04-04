using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMovement : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    public Vector2 moveDirection;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Вращаем объект, если это необходимо
        m_Rigidbody.transform.Rotate(0, 0, 1);

        // Задаем скорость движения напрямую через Rigidbody для корректной работы с физикой
        m_Rigidbody.velocity = moveDirection.normalized * moveSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    public float moveSpeed = 2;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Animator ShootAnimator;
    public int bulletSpeed;
    public EngineAudioHandler engineAudioHandler;
    private Rigidbody2D _playerRigidbody;
    private AudioSource _audioSourcePlayer;
    private Animator _playerAnimator;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _audioSourcePlayer = GetComponent<AudioSource>();
        _playerAnimator = GetComponent<Animator>();

    }
    private void Update()
    {
        PlayerMovement();
    }

    public void Shoot()
    {
        ShootAnimator.SetTrigger("Shoot");
        _audioSourcePlayer.Play();
        // Создаем экземпляр пули
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Получаем компонент Rigidbody2D пули
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Задаем скорость движения пули
        rb.velocity = transform.up * bulletSpeed; // Пуля летит вправо от корабля. Можете изменить направление в зависимости от ориентации корабля.
    }

    private void PlayerMovement()
    {
        float movementY = Mathf.Clamp(_joystick.Vertical, -1, 1);
        float movementX = Mathf.Clamp(_joystick.Horizontal, -1, 1);

        // Ограничиваем движение по оси Y
        if (transform.position.y >= 4.5f && movementY > 0)
        {
            movementY = 0;
        }
        else if (transform.position.y <= -4.5f && movementY < 0)
        {
            movementY = 0;
        }

        // Ограничиваем движение по оси X
        if (transform.position.x >= 10f && movementX > 0)
        {
            movementX = 0;
        }
        else if (transform.position.x <= -10f && movementX < 0)
        {
            movementX = 0;
        }


        _playerRigidbody.velocity = new Vector3(movementX * moveSpeed, movementY * moveSpeed);
        if (_joystick.Vertical > 0.3)
        {
            engineAudioHandler.IncreasePitch();
            if (transform.rotation.z < -0.5)
            {
                transform.Rotate(0, 0, 2);
            }
        }
        if (_joystick.Vertical < -0.3)
        {
            engineAudioHandler.DecreasePitch();
            if (transform.rotation.z > -0.9)
            {
                transform.Rotate(0, 0, -2);
            }
        }
        if (_joystick.Vertical < 0.3 && _joystick.Vertical > -0.3)
        {
            engineAudioHandler.ResetPitch();
            if (transform.rotation.z > -0.7)
            {
                transform.Rotate(0, 0, -2);
            }
            if (transform.rotation.z < -0.7)
            {
                transform.Rotate(0, 0, 2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="SmallAsteroid")
        {
            _playerAnimator.SetTrigger("PlayerHitted");
            collision.GetComponent<AsteroidBehavior>().DestroyAsteroid(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    private SmallAsteroid smallAsteroid;
    public ParticleSystem ExplosionParticles;
    public SoundFXManager soundFXManager;
    public LevelManager levelManager;
    private void onAsteroidHit()
    {
        soundFXManager.PlayAsteroidHit();
        smallAsteroid.HitPoints--;
        if (smallAsteroid.HitPoints==0)
        {
            DestroyAsteroid(false);
        }
    }

    public void DestroyAsteroid(bool isAfterPlayerHit)
    {
        if (isAfterPlayerHit)
        {
            levelManager.PlayerHPDecrease();
        }
        soundFXManager.PlayAsteroidExplosion();
        Instantiate(ExplosionParticles,transform.position,Quaternion.identity);
        levelManager.SmallAsteroidDestroyed();
        Destroy(gameObject);
    }

    void Start()
    {
        smallAsteroid = new SmallAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {
            onAsteroidHit();
            Destroy(collision.gameObject);
        }

    }
}

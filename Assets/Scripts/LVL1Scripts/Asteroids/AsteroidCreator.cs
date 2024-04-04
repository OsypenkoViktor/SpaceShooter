using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    public SoundFXManager SoundFXManager;
    public LevelManager levelManager;
    public GameObject AsteroidPrefab;
    public float asteroidsPerSecond;
    public int asteroidSpeed;
    [Range(-1, 1)]
    public float minX;
    [Range(-1, 1)]
    public float minY;
    [Range(-1, 1)]
    public float maxX;
    [Range(-1, 1)]
    public float maxY;

    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    public void StartAsteroidsCreation()
    {
        InvokeRepeating("CreateAsteroid", 0f, 1f/asteroidsPerSecond);
    }

    public void CreateAsteroid()
    {
        Vector2 randomPoint = new Vector2(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y)
        );

        RaycastHit2D hit = Physics2D.Raycast(randomPoint, Vector2.down);

        if (hit.collider != null)
        {
            Vector3 randomPosition = hit.point;

            AsteroidsMovement currentAsteroidMovementScript = AsteroidPrefab.GetComponent<AsteroidsMovement>();
            currentAsteroidMovementScript.moveDirection = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );
            currentAsteroidMovementScript.moveSpeed = asteroidSpeed;

            GameObject currentAsteroidGameObject =  Instantiate(AsteroidPrefab, randomPosition, Quaternion.identity);
            currentAsteroidGameObject.GetComponent<AsteroidBehavior>().soundFXManager = SoundFXManager;
            currentAsteroidGameObject.GetComponent<AsteroidBehavior>().levelManager = levelManager;
        }
        else
        {
            Debug.LogWarning("Raycast didn't hit anything, unable to create asteroid.");
        }
    }
}

using UnityEngine;

public class CanSpawnerMother : MonoBehaviour
{
    public GameObject[] spawnPoints; //list for available spawnpoints
    public GameObject canPrefab;
    private bool CansAreSpawning = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !CansAreSpawning)
        {
            CansAreSpawning = true;
            InvokeRepeating("SpawnLogic",0f, 3f);
            
        }        
    }
    void SpawnLogic()
    {
        // Always spawn the first can
        SpawnRandomCan();

        // 20% chance to spawn a second "Bonus" can
        if (Random.value < 0.2f) 
        {
            // Add a tiny random delay so they don't overlap perfectly in the air
            float tinyDelay = Random.Range(0.1f, 0.5f);
            Invoke("SpawnRandomCan", tinyDelay);
        }
    }
    void SpawnRandomCan()
    {
        int randomIndex = Random.Range(0,spawnPoints.Length);
        GameObject newCan = Instantiate(canPrefab, spawnPoints[randomIndex].transform.position, Quaternion.identity);
        Rigidbody2D rb = newCan.GetComponent<Rigidbody2D>();
        //Transform spawner = spawnPoints[randomIndex].transform;

        //Instantiate(canPrefab, spawner.position,spawner.rotation);
        if (randomIndex <= 1)
        {
            rb.AddForce(new Vector2(Random.Range(5f,10f), 7.5f), ForceMode2D.Impulse);
        }
        else 
        {
            rb.AddForce(new Vector2(Random.Range(-5f,-10f), 7.5f), ForceMode2D.Impulse);
        }

    }
}

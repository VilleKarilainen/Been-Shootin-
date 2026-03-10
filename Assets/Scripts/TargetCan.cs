using UnityEngine;

public class TargetCan : MonoBehaviour
{
    public int health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private GunScript gunScript; 
    void Start()
    {
        gunScript = Object.FindAnyObjectByType<GunScript>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //randomize can health
        float probabilityRoll = Random.value;
        if (probabilityRoll <= 0.25f) // 25% chance the can spawned has 1 HP
        {
            health = 1;
        }
        else
        {
            health = Random.Range(2,4); // 75% chance the can spawned has more than 1HP, requiring a follow-up
        }
        health = Random.Range(1,4);
        ColorCheck();
    }
    void ColorCheck()
    {
        if (health == 3)
        {
            sr.color = Color.green;
        }
        else if (health == 2)
        {
            sr.color=Color.yellow;
        }
        else if (health == 1)
        {
            sr.color = Color.red;
        }
    }
    void OnMouseDown() 
    {
        // check if you have bullets, then the can gets hit
        if(gunScript.ammo > 0)
        {
        
        health--;
        ColorCheck();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            
            // "Pops" the can when it's hit
            Vector2 bounce = new Vector2(Random.Range(-10f, 10f), Random.Range(0f, 7f));
            rb.linearVelocity = bounce;

            //adds spin to the can when shot
            rb.AddTorque(Random.Range(-5f, 5f), ForceMode2D.Impulse);

        }
        Debug.Log("Can shot! remaining health: "+health);
        }
        
    }
}

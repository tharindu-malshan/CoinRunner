
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float fallLimitY = -10f;

    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player has fallen
        if (transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

    // Trigger for collecting coins
    
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("Coin"))
    {
        GameManager.instance.AddCoin();
        Destroy(other.gameObject);
    }

    if (other.CompareTag("Goal"))
    {
        GameManager.instance.LevelComplete();
    }
    }


    // Collision for touching spikes
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
    }
}

// This script is responsible for the logic of the bullet.
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float deathTimer = 2f;
    private float timeTillDeath;
    [HideInInspector]
    public string homeObject;
    public float dir { get; set; }
    public float speed = 20f;
    private Vector3 velocity;
    private Rigidbody2D bulletBody;
    private BoxCollider2D bulletCol;
    private ScoreSystem scoreSystem;
    void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        bulletBody = GetComponent<Rigidbody2D>();
        timeTillDeath = deathTimer + Time.time;
        velocity = new Vector3(0, speed, 0);
        // dir is responsible for the direction of the bullet (whether it is going up or down)
        dir = 1;
    }
    void OnTriggerEnter2D(Collider2D objCollider)
    {
        // if the bullet hits the edge of the screen it is destroyed.
        if (objCollider.tag == "DeathWall")
        {
            Destroy(gameObject);
        }
        // if the bullet is an evil bullet or spawned by the shooter and it hits the player, it destroys the player
        // This exists so that the bullet doesn't destroy the object that spawned it
        if (gameObject.tag == "EvilBullet" && objCollider.tag == "Player")
        {
            Kill(objCollider);
            Destroy(gameObject);

        }
        // if the player shoots a shooter they get 10 points
        else if (gameObject.tag == "Bullet" && objCollider.tag == "Shooter")
        {
            Kill(objCollider);
            //score.score += 10;
            Destroy(gameObject);
        }
        // if the player shoots an asteroid they get 6 points
        else if (objCollider.tag == "Asteroid" && gameObject.tag == "Bullet")
        {
            Kill(objCollider);
            //score.score += 6;
            Destroy(gameObject);
        }

    }
    void FixedUpdate()
    {
        // after a fixed amount of time the bullet will be destroyed;
        if (Time.time > timeTillDeath)
        {
            Destroy(gameObject);
        }
        // move the bullet
        bulletBody.AddForce(velocity);
    }
    // this method is used to destroy any game objects the bullet hits
    // it finds a Destructible component on the object and calls the Die function which sets off an explosion particle effect
    // then it destroys itself
    private void Kill(Collider2D objCollider)
    {
        objCollider.gameObject.GetComponent<Destructible>().Die();
    }
    void Update()
    {
        // in case i need to put things here
    }
}

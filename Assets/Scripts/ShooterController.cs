// This script controls the shooter gameobject
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawn;
    // Sine points are the two points between which the shooter will continuously move
    [SerializeField]
    private Transform[] sinePoints;
    [SerializeField]
    private float shootInterval;
    private float timeTillNextShot;
    [SerializeField]
    private float moveInterval;
    private float timeTillNextMove = 0f;
    private Rigidbody2D playerBody;
    private int traj;
    [SerializeField]
    private float moveSpeed;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        traj = 0;
        timeTillNextMove = moveInterval;
        timeTillNextShot = shootInterval;
    }

    void Update()
    {
        MechanicsLoop();
    }
    private void OnCollisionEnter2D(Collision2D objCollider)
    {
        // Shooters will not collide with other Shooters
        if (objCollider.collider.tag == tag)
        {
            Physics2D.IgnoreCollision(objCollider.collider, GetComponent<Collider2D>());
        }
        // Shooters will not collide with Asteroids
        else if (objCollider.collider.tag == "Asteroid")
        {
            Physics2D.IgnoreCollision(objCollider.collider, GetComponent<Collider2D>());
        }
        // Otherwise if the shooter collides with anything it will change its trajectory
        else
        {
            if (traj == 0)
            {
                traj = 1;
            }
            else if (traj == 1)
            {
                traj = 0;
            }
        }
    }
    // This method is responsible for all the logic of the shooter
    private void MechanicsLoop()
    {
        // Step controls how much the shooter moves every frame
        float step = Time.deltaTime * moveSpeed;
        // If the shooter is close enough to a sine point it will change it's trajectory
        if (Vector2.Distance(transform.position, sinePoints[traj].transform.position) < 0.001f)
        {
            trajSwap();
        }
        // The shooter will take a step towards the sinepoint every frame
        transform.position = Vector2.MoveTowards(transform.position, sinePoints[traj].transform.position, step);
        // If a certain time interval has passed the shooter will change its trajectory
        if (Time.time > timeTillNextMove)
        {
            trajSwap();
        }
        // The shooter will shoot 1 bullet at a regulated interval
        if (Time.time > timeTillNextShot)
        {
            Shooter();
        }

    }
    // This method is responsible for shooting bullets
    private void Shooter()
    {
        timeTillNextShot = Time.time + shootInterval;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletPrefab.transform.rotation);
        bullet.GetComponent<Bullet>().homeObject = "Shooter";
        // This makes sure the bullet goes downward instead of upward which is the default
        bullet.GetComponent<Bullet>().speed *= -1;
    }
    // this method swaps the trajectory of the shooter between each sinepoint
    private void trajSwap()
    {
        timeTillNextMove = Time.time + moveInterval;
        if (traj == 0)
        {
            traj = 1;
        }
        else if (traj == 1)
        {
            traj = 0;
        }
    }
}

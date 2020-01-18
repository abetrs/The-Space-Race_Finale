using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceshipController : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody2D playerBody;
    public Transform playerTransform;
    public List<Transform> bulletSpawns;
    public float moveSpeed;
    private float speedY = 10;
    public GameObject bulletPrefab;
    public float RateOfFire;
    private Vector3 velocity;
    private bool IsMoving = false;
    private ScoreSystem scoreSystem;
    void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }
    public void MechanicsLoop()
    {
        // Movement
        moveSpeed = Input.GetAxis("Horizontal1");
        speedY = Input.GetAxis("Vertical1");
        velocity.Set(moveSpeed, speedY, 0);
        playerBody.MovePosition(playerTransform.position + velocity);

        // Shooter code
        if (Input.GetKey(KeyCode.Space))
        {
            if (RateOfFire < Time.time)
            {
                Shoot();
                RateOfFire = Time.time + 0.5f;
            }
        }
    }
    // Shoots bullets
    public void Shoot()
    {
        scoreSystem.AddScore(1, "Player1");
        GameObject bullet1 = Instantiate(bulletPrefab, bulletSpawns[0].position, bulletPrefab.transform.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, bulletSpawns[1].position, bulletPrefab.transform.rotation);
        bullet1.GetComponent<Bullet>().homeObject = "Player1";
        bullet2.GetComponent<Bullet>().homeObject = "Player1";
    }
    // Checks if player is moving
    public void MovementCheck()
    {
        if (speedY <= 0)
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
        }
    }
    // Tells the animator whether the player is moving or not
    public void Animate()
    {
        if (IsMoving)
        {
            playerAnim.SetBool("IsMoving", true);
        }
        else if (!IsMoving)
        {
            playerAnim.SetBool("IsMoving", false);
        }
    }
    // Loads the game over scene when the player dies
    private void OnDestroy()
    {
        if (SceneManager.GetActiveScene().name == "SingeplayerScene")
        {
            SceneManager.LoadScene("SP_GameOver");
        }
        else
        {
            SceneManager.LoadScene("MP_GameOver");
        }
    }

}



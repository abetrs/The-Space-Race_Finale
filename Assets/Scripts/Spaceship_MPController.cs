using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship_MPController : MonoBehaviour
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
    private ScoreSystem scoreSystem;
    private bool IsMoving = false;
    void Start()
    {

    }
    public void MechanicsLoop()
    {
        // Movement
        moveSpeed = Input.GetAxis("Horizontal2");
        speedY = Input.GetAxis("Vertical2");
        velocity.Set(moveSpeed, speedY, 0);
        playerBody.MovePosition(playerTransform.position + velocity);

        // Shooter code
        if (Input.GetKey(KeyCode.Return))
        {
            if (RateOfFire < Time.time)
            {
                Shoot();
                RateOfFire = Time.time + 0.5f;
            }
        }
    }
    public void Shoot()
    {
        scoreSystem.AddScore(1, "Player2");
        GameObject bullet1 = Instantiate(bulletPrefab, bulletSpawns[0].position, bulletPrefab.transform.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, bulletSpawns[1].position, bulletPrefab.transform.rotation);
        bullet1.GetComponent<Bullet>().homeObject = "Player2";
        bullet2.GetComponent<Bullet>().homeObject = "Player2";
    }
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
    private void OnDestroy()
    {
        SceneManager.LoadScene("MP_GameOver");
    }

}



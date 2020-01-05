// This class tells Unity what to do with the UFO.
using UnityEngine;
using System.Collections.Generic;

public class UFO : MonoBehaviour, Spaceship
{

    public float speed { get; set; } = 12;
    public float dps { get; set; } = 11;
    public float startAmmo { get; set; } = 100;
    public List<Transform> bulletSpawn { get; set; }
    public GameObject bulletPrefab { get; set; }
    // Reference to the ufo controller
    private UFOController controller;

    private void Start()
    {
        controller = GetComponent<UFOController>();
    }

    private void OnCollisionEnter2D(Collision2D objCollision)
    {
        // Two players cannot collide with each other
        Collider2D objCollider = objCollision.collider;
        if (objCollider.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(objCollider, GetComponent<Collider2D>());
        }
    }

    private void FixedUpdate()
    {
        // Calls controller functions
        controller.MechanicsLoop();
    }
    private void Update()
    {
        controller.MovementCheck();
        controller.Animate();
    }
}
// This class tells Unity what to do with the UFO.
using UnityEngine;

public class Spaceship : MonoBehaviour
{

    // Reference to the ufo controller
    private SpaceshipController controller;

    private void Start()
    {
        controller = GetComponent<SpaceshipController>();
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
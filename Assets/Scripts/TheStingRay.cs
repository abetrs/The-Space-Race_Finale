// This class tells Unity what to do with the Sting Ray.
// Basic code is almost identical to the UFO
using UnityEngine;
using System.Collections.Generic;

public class TheStingRay : MonoBehaviour, Spaceship
{

    public float speed { get; set; } = 12;
    public float dps { get; set; } = 11;
    public float startAmmo { get; set; } = 100;
    public List<Transform> bulletSpawn { get; set; }
    public GameObject bulletPrefab { get; set; }
    private TheStingRayController controller;

    private void Start()
    {
        controller = GetComponent<TheStingRayController>();
    }

    private void OnCollisionEnter2D(Collision2D objCollision)
    {
        Collider2D objCollider = objCollision.collider;
        if (objCollider.gameObject.tag == "Shooter")
        {
            Destroy(gameObject.gameObject);
        }
    }

    private void FixedUpdate()
    {
        controller.MechanicsLoop();
    }
    private void Update()
    {
        controller.MovementCheck();
        controller.Animate();
    }
}
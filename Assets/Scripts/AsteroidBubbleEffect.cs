// This script manages the asteroids in the game.
using UnityEngine;

public class AsteroidBubbleEffect : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D objCollision)
    {
        Collider2D objCollider = objCollision.collider;
        // if the asteroid hits a wall it gets destroyed;
        if (objCollider.tag == "DeathWall")
        {
            Destroy(gameObject);
        } else if (objCollider.tag == "Player")
        {
            // If the asteroid hits the player it calls the Die method of the player to cause them to explode.
            objCollider.gameObject.GetComponent<Destructible>().Die();
        }
    }
    void Update()
    {

    }


}

// This script is a class that attaches to every object that can be destroyed
using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Prefab for explosion particle effect
    public GameObject explosionPF;
    // Color of explosion particles
    public Color explosionColor;
    // The sprite that determines the shape of the particle effect
    [HideInInspector]
    public Sprite objSprite;

    public void Awake()
    {
        objSprite = GetComponent<SpriteRenderer>().sprite;
    }
    // The die function is responsible for safely destroying all game objects it is attached to
    // First it sets off the explosion particle effect
    // It sets the color of the particles to the color of the sprite of the game object that is being destroyed
    // It sets the shape of the particle effect to the sprite of the game object that is being destroyed
    // Then it destroys the game object
    public void Die()
    {
        explosionPF = Instantiate(explosionPF, transform.position, transform.rotation);
        explosionPF.GetComponent<ExplosionController>().SetColor(explosionColor);
        explosionPF.GetComponent<ExplosionController>().SetSprite(objSprite);
        Destroy(gameObject);
    }
}

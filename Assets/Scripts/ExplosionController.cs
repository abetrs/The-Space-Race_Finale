// Responsible for controlling the explosion particle effect
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.MainModule psMain;
    ParticleSystem.ShapeModule psShape;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        psMain = ps.main;
        psShape = ps.shape;
    }
    // sets the color of the particle effect
    public void SetColor(Color color)
    {
        psMain.startColor = color;
    }
    // sets the shape of the particle effect to a sprite
    public void SetSprite(Sprite sprite)
    {
        psShape.sprite = sprite;
    }
}

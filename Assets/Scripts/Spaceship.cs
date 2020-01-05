// This interface is an outline for the properties of each spaceship
// I don't end up using this in the end for my Spaceships and instead write duplicate code which I hope to patch in the future
using UnityEngine;
using System.Collections.Generic;
interface Spaceship
{
    float speed { get; set; }
    float dps { get; set; }
    float startAmmo { get; set; }
    List<Transform> bulletSpawn { get; set; }
    GameObject bulletPrefab { get; set; }
}
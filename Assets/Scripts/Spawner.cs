// This script spawns obstacles
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float score;
    // This is the time until the next object spawns
    [SerializeField]
    private float spawnTime;
    // This is the position where the object will spawn
    private float spawnPos;
    // This is the time until difficulty increases
    [SerializeField]
    private float difficultyIncreaseTime = 60f;
    // This is a random number that determins where on the x-axis it can spawn
    private float randomNumber;
    private float timeTillNextSpawn;
    // Prefabs for all the different asteroids that can spawn
    [SerializeField]
    private GameObject BigAsteroidPrefab;
    [SerializeField]
    private GameObject SmallAsteroidPrefab;
    [SerializeField]
    private GameObject MediumAsteroidPrefab;
    [SerializeField]
    private GameObject VolcanicAsteroidPrefab;
    [SerializeField]
    private GameObject ShooterPrefab;
    // These are the y positions where the two objects will spawn
    [SerializeField]
    private Transform shooterAxis;
    [SerializeField]
    private Transform asteroidAxis;
    void Start()
    {
        timeTillNextSpawn = spawnTime;
    }
    
    void Update()
    {
        if (Time.time > timeTillNextSpawn)
        {
            timeTillNextSpawn = Time.time + spawnTime;
            Spawn();
        }
        // Every few seconds the time between spawns decreases and the time until the next difficulty increase also decreases
        // This raises the difficulty of the game exponentially as you move forward into the game
        if (Time.time > difficultyIncreaseTime)
        {
            difficultyIncreaseTime = (difficultyIncreaseTime * 0.75f) + Time.time;
            spawnTime *= 0.75f;
        }
    }
    // This method uses a random number to determine which obstacle to spawn
    // Some obstacles have a higher chance of spawning
    private void Spawn()
    {
        spawnPos = Random.Range(-10, 10);
        randomNumber = Random.Range(1, 11);
        if (randomNumber == 1)
        {
            SpawnAsteroid("Big");
        }
        else if (randomNumber == 2 || randomNumber == 3 || randomNumber == 4)
        {
            SpawnAsteroid("Small");
        }
        else if (randomNumber == 5 || randomNumber == 6)
        {
            SpawnAsteroid("Medium");
        }
        else if (randomNumber == 7 || randomNumber == 8)
        {
            SpawnShooter();
        }
        else if (randomNumber == 9 || randomNumber == 10)
        {
            SpawnAsteroid("Volcanic");
        }
    }
    // This method spawns an asteroid with a variable for which type of asteroid to spawn
    private void SpawnAsteroid(string type)
    {
        switch (type)
        {
            case "Big":
                Instantiate(BigAsteroidPrefab, new Vector3(spawnPos, asteroidAxis.position.y, 0), BigAsteroidPrefab.transform.rotation);
                break;
            case "Medium":
                Instantiate(MediumAsteroidPrefab, new Vector3(spawnPos, asteroidAxis.position.y, 0), MediumAsteroidPrefab.transform.rotation);
                break;
            case "Small":
                Instantiate(SmallAsteroidPrefab, new Vector3(spawnPos, asteroidAxis.position.y, 0), SmallAsteroidPrefab.transform.rotation);
                break;
            case "Volcanic":
                Instantiate(VolcanicAsteroidPrefab, new Vector3(spawnPos, asteroidAxis.position.y, 0), Quaternion.Euler(new Vector3(VolcanicAsteroidPrefab.transform.rotation.x, VolcanicAsteroidPrefab.transform.rotation.y, Random.Range(0f, 360f))));
                break;
        }
    }
    // Spawns a shooter
    private void SpawnShooter()
    {
        Instantiate(ShooterPrefab, new Vector3(spawnPos, shooterAxis.position.y, 0), ShooterPrefab.transform.rotation);
    }
}

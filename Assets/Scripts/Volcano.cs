using UnityEngine;

public class Volcano : MonoBehaviour
{
    public GameObject meteroidPrefab;
    public Transform meteroidSpawn;
    private float randomNumber;
    private float willSpawn;
    private bool hasSpawned = false;
    private void Awake()
    {
        randomNumber = Random.Range(1, 3);
        willSpawn = Random.Range(1, 3);
    }
    private void Update()
    {
        if (randomNumber == willSpawn)
        {
            if (!hasSpawned)
            {
                hasSpawned = true;
                Instantiate(meteroidPrefab, meteroidSpawn.position, meteroidPrefab.transform.rotation);
            }
        }   
    }
}

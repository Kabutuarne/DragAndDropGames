using UnityEngine;

public class ObstaclesSpawnerScript : MonoBehaviour
{
    public GameObject[] cloudsPrefabs;
    public GameObject[] objectsPrefabs;
    public Transform spawnPoint;
    public float cloudSpawnInterval = 3f;
    public float obstacleSpawnInterval = 2f;
    public float minY = -540f;
    public float maxY = 540f;

    public float cloudMinSpeed = 1.5f;
    public float cloudMaxSpeed = 150f;
    
    public float obstacleMinSpeed = 2f;
    public float obstacleMaxSpeed = 200f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnCloud), 0f, cloudSpawnInterval);
        InvokeRepeating(nameof(SpawnObstacles), 0f, obstacleSpawnInterval);

    }
    void SpawnCloud()
    {
        if (cloudsPrefabs.Length == 0)
        {
            return;
        }
        GameObject cloudPrefab = cloudsPrefabs[Random.Range(0, cloudsPrefabs.Length)];
        float y = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, y, spawnPoint.position.z);
        GameObject cloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity, spawnPoint);
        float movementSpeed = Random.Range(cloudMinSpeed, cloudMaxSpeed);
        ObstaclesControllerScript controller = cloud.GetComponent<ObstaclesControllerScript>();
        controller.speed = movementSpeed;
    }
    void SpawnObstacles()
    {
        if (objectsPrefabs.Length == 0)
        {
            return;
        }
        GameObject obstaclePrefab = objectsPrefabs[Random.Range(0, objectsPrefabs.Length)];
        float y = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(-spawnPoint.position.x, y, spawnPoint.position.z);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, spawnPoint);
        float movementSpeed = Random.Range(obstacleMinSpeed, obstacleMaxSpeed);
        ObstaclesControllerScript controller = obstacle.GetComponent<ObstaclesControllerScript>();
        controller.speed = -movementSpeed;
    }



    void Update()
    {
        
    }
}

using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

    public GameObject[] ObstablePrefabs;

    public void SpawnObstacles(int numObstacles)
    {
        for (int i = 0; i < numObstacles; i++)
            SpawnObstacle();
    }

    public void SpawnObstacle()
    {
        //Find a position to spawn an obstacle
        Vector3 position = GetObstacleSpawnLocation();

        //Pick a random obstacle to create
        GameObject randomObstacle = ObstablePrefabs[Random.Range(0, ObstablePrefabs.Length)];

        //Spawn the obstacle
        GameObject obstacle = Instantiate(randomObstacle, position, Quaternion.identity) as GameObject;

        //Set the parent of the obstacle to this gameobject
        obstacle.transform.parent = this.gameObject.transform;
    }

    public Vector3 GetObstacleSpawnLocation()
    {
        return new Vector3(
            Random.Range(LevelManager.MinimumX, LevelManager.MaximumX),
            LevelManager.ObstacleY,
            Random.Range(LevelManager.MinimumZ, LevelManager.MaximumZ));
    }
}

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    //the 5 planes that encapsulate the level
    public GameObject GroundPlane;
    public GameObject NorthPlane;
    public GameObject SouthPlane;
    public GameObject WestPlane;
    public GameObject EastPlane;

    //Level Boundaries
    public static float MinimumX;
    public static float MaximumX;
    public static float MinimumZ;
    public static float MaximumZ;
    public static float FishY;
    public static float GroundY;
    public static float ObstacleY;

    //managers that the level needs to interact with
    public ObstacleManager ObstacleManager;

	// Use this for initialization
	void Start () {
        //get level data
        Vector2 dimensions = new Vector2(10.0f, 10.0f);
        int level = 1;

        //generate the level
        GenerateLevel(dimensions, level);
	}

    public void GenerateLevel(Vector2 dimensions, int level)
    {
        //set up the map boundaries
        SetMapBoundaries(dimensions);

        //set up obstacles
        ObstacleManager.SpawnObstacles(20);
    }

    public void SetMapBoundaries(Vector2 dimensions)
    {
        //fix the ground plane scaling
        GroundPlane.transform.localScale = new Vector3(dimensions.x, 1, dimensions.y);

        //fix the position of the walls
        NorthPlane.transform.SetPositionZ(5 * dimensions.y);
        SouthPlane.transform.SetPositionZ(-5 * dimensions.y);
        EastPlane.transform.SetPositionX(5 * dimensions.x);
        WestPlane.transform.SetPositionX(-5 * dimensions.x);

        //set our static level boundary data
        MinimumX = WestPlane.transform.position.x;
        MaximumX = EastPlane.transform.position.x;
        MinimumZ = SouthPlane.transform.position.z;
        MaximumZ = NorthPlane.transform.position.z;
        FishY = 0.0f;
        GroundY = -1.0f;
        ObstacleY = -2.0f;
    }
}

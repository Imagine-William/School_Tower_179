using UnityEngine;
using System.Collections;

public class FishStats : MonoBehaviour {

    //The level of the fish
    public int Level;

    //How much the fish is scaled per level
    public float ScalingFactor;

    //How many fish to eat before the fish grows
    public int FishUntilGrowth;

	// Use this for initialization
	void Start () {
        float scale = 1.0f + (Level * ScalingFactor);
        transform.localScale = new Vector3(scale, scale, scale);
	}
}

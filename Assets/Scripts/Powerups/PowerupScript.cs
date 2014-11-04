using UnityEngine;
using System.Collections;

public enum PowerupType
{
    Speed
}

public class PowerupScript : MonoBehaviour {

    //The type of powerup
    public PowerupType PowerupType;

    //the duration of the powerup
    public float Duration;

    //The strength of the powerup (velocity multiplier for speed buff)
    public float Strength;
	
	// Update is called once per frame
	void Update () {
	    //powerup does nothing for now...
	}
}

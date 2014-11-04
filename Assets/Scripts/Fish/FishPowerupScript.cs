using UnityEngine;
using System.Collections;

public class PowerupInfo
{
    //The type of powerup
    public PowerupType Type;

    //The duration of the powerup
    public float Duration;

    //The strength of the powerup
    public float Strength;

    public PowerupInfo() { }
}

public class FishPowerupScript : MonoBehaviour
{
    //Speed Powerup Data
    public PowerupInfo SpeedPowerup = new PowerupInfo();

    // Update is called once per frame
    void Update()
    {
        //reduce the duration of powerups
        SpeedPowerup.Duration -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        //if the player's fish collided with an AI fish
        if (other.tag == "Powerup")
        {
            //get the powerup script
            PowerupScript powerup = other.gameObject.GetComponent<PowerupScript>();

            //apply the powerup based on type
            switch (powerup.PowerupType)
            {
                case PowerupType.Speed:
                    SpeedPowerup.Duration = powerup.Duration;
                    SpeedPowerup.Strength = powerup.Strength;
                    break;
                default:
                    break;
            }

            //delete the powerup
            Destroy(other.gameObject);
        }
    }

    //returns true if the duration for the powerup is greater than 0
    public bool HasPowerup(PowerupType type)
    {
        switch (type)
        {
            case PowerupType.Speed:
                return SpeedPowerup.Duration > 0.0f;
            default:
                break;
        }

        return false;
    }

    //returns the strength of a powerup
    public float GetPowerupStrength(PowerupType type)
    {
        switch (type)
        {
            case PowerupType.Speed:
                return SpeedPowerup.Strength;
            default:
                break;
        }

        return 0.0f;
    }
}

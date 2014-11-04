using UnityEngine;
using System.Collections;

public class FishEatingScript : MonoBehaviour
{
    public FishStats PlayerFish;

	public FishStats AIFish;

    void OnTriggerEnter(Collider other)
    {
        //if the player's fish collided with an AI fish
        if (other.tag == "AIFish")
        {
            //get the other fish's level
            int otherFishLevel = other.GetComponent<FishStats>().Level;

            //if we are bigger than the fish
            if (PlayerFish.Level > otherFishLevel)
            {
                //eat the other fish
                Destroy(other.gameObject);
                PlayerFish.FishUntilGrowth -= 1;
            }

        }
		/*if (other.tag == "Player")
		{
			//get the other fish's level
			int otherFishLevel = other.GetComponent<FishStats>().Level;
			
			//if we are bigger than the fish
			if (AIFish.Level > otherFishLevel)
			{
				//eat the other fish
				Destroy(other.gameObject);
				//PlayerFish.FishUntilGrowth -= 1;
			}
			
		}*/
	}
}

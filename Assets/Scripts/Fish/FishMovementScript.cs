using UnityEngine;
using System.Collections;

public class FishMovementScript : MonoBehaviour
{
	//Whether or not this fish is controlled by the player
	public bool PlayerControlled;
	
    //The powerup script for the player fish
    public FishPowerupScript FishPowerupScript;

	//The destination the fish is moving to
	private Vector3 destination = new Vector3();
	private Vector3 AIdestination = new Vector3();
	
	//How close the fish needs to be to the destination before it stops moving
	private float destinationTolerance = 0.2f;
	
	//If the fish is moving toward its destination or not
	private bool isMoving;
	
	//The velocity of the fish
	public float velocity;

	// cur Touch tells us which touch we look at, as it might change before we get to first touch location.
	private int curTouch = 0;
	// touch2Watch gives us where we should go too.
	private int touch2Watch = 64;
	private Transform myTrans, camTrans;

	//set timer to delay the movement
	private float TimeBetweenAIUpdate = 3.0f;
	private float aiUpdateTimer = 0.0f;

	//set the palyer to be the target 
	public GameObject player;
	
	void Start()
	{
		myTrans = this.transform;
		camTrans = Camera.main.transform;
		player.transform.localPosition = new Vector3(0, 1, 0);
	}
	
	// Update is called once per frame
	void Update()
	{
		//if we are player controlled
		if (PlayerControlled)
		{
			//get input from the player to move the fish
			GetPlayerInputKeyboard();
            GetPlayerInputTouch();
			if (isMoving)
			{
				
				//check if we are within tolerance of our destination
				float distanceToDestination = (this.transform.position - destination).magnitude;
				if (distanceToDestination > destinationTolerance)
				{
					//we are not within tolerance, so get the direction vector to the destination
					Vector3 direction = (destination - this.transform.position).normalized;
					
					//determine the movement vector based on the direction
					Vector3 movement = direction * velocity * Time.deltaTime;
					//player.transform.position = movement;
					
					//and move the fish based on the movement vector
					MoveFish(movement);
				}
				else
				{
					//we are within tolerance
					isMoving = false;
				}
				
			}
		}
			else
			{
				//get input from the ai to move the fish
				FishAIUpdate();
				if (isMoving)
				{
					
					//check if we are within tolerance of our destination
					float distanceToDestination = (this.transform.position - destination).magnitude;
					if (distanceToDestination > destinationTolerance)
					{
						//we are not within tolerance, so get the direction vector to the destination
						Vector3 direction = (destination - this.transform.position).normalized;
						
						//determine the movement vector based on the direction
						Vector3 movement = direction * velocity * Time.deltaTime;
						
						//and move the fish based on the movement vector
						AIMoveFish(movement);
					}
					else
					{
						//we are within tolerance
						isMoving = false;
					}
				}
				
				
				
			}
			
			Debug.Log (player.transform.position);
			
			//reset physics so that the fish doesn't get pushed out of the game
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		transform.SetPositionY(1.0f);
	}
	
	private void GetPlayerInputKeyboard()
	{
		Vector3 direction = new Vector3();
		
		//read player input to determine the direction to move the fish
		
		if (Input.GetKey(KeyCode.W))
			direction.z = 1.0f;
		if (Input.GetKey(KeyCode.S))
			direction.z = -1.0f;
		if (Input.GetKey(KeyCode.A))
			direction.x = -1.0f;
		if (Input.GetKey(KeyCode.D))
			direction.x = 1.0f;
		
		
        if (direction != Vector3.zero)
        {
            //determine the movement vector to move the fish
            Vector3 movement = direction * velocity * Time.deltaTime;


            //and then apply it to the fish
            MoveFish(movement);
        }
        
	}

    private void GetPlayerInputTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {

                if (touch.phase == TouchPhase.Began)
                {
                    touch2Watch = curTouch;
                }
                curTouch = touch.fingerId;
                Vector3 TouchPos = new Vector3(Input.GetTouch(touch2Watch).position.x, Input.GetTouch(touch2Watch).position.y, camTrans.position.y - myTrans.position.y);
                Vector3 temp = Camera.main.ScreenToWorldPoint(TouchPos);
                //Vector3 finalPos = Camera.main.ScreenToWorldPoint(TouchPos);
                myTrans.LookAt(temp);
                SetDestination(temp);
				AIdestination = temp;

            }
        }
    }
    
	private void FishAIUpdate()
	{
		//set direction for the fish, it will move in that direction based on its velocity
		
		//In update()

		//check the range
		if (Vector3.Distance (transform.position, player.transform.position) <= 25) {

				//Debug.Log(AIdestination.x + ":" + AIdestination.z);
					AIdestination = player.transform.localPosition;
					SetDestination (AIdestination);

				} else {
						//random swim
						aiUpdateTimer -= Time.deltaTime;
						if (aiUpdateTimer <= 0.0f) {

								destination.x = Random.Range (-40, 40);
								destination.y = 1;
								destination.z = Random.Range (-40, 40);

								//update the ai here, this only happens every 10.0f seconds
								SetDestination (destination);
								aiUpdateTimer = TimeBetweenAIUpdate;
						}
				}
	}
	
	//Tells the fish to start moving toward a given destination
	public void SetDestination(Vector3 destination)
	{
		this.destination = new Vector3(destination.x, 1, destination.z);
		isMoving = true;
	}
	
	public void MoveFish(Vector3 movement)
	{
        //apply speed powerup if we have it
        if (PlayerControlled && FishPowerupScript.HasPowerup(PowerupType.Speed))
            movement *= FishPowerupScript.GetPowerupStrength(PowerupType.Speed);
	
		//move the fish
		transform.position += movement;
		player.transform.position += movement;
		
		//and rotate it to face the new direction
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 3.0f * Time.deltaTime);
	}

	public void AIMoveFish(Vector3 movement)
	{
		//apply speed powerup if we have it
		if (PlayerControlled && FishPowerupScript.HasPowerup(PowerupType.Speed))
			movement *= FishPowerupScript.GetPowerupStrength(PowerupType.Speed);
		
		//move the fish
		transform.position += movement;
		
		//and rotate it to face the new direction
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 3.0f * Time.deltaTime);
	}
}

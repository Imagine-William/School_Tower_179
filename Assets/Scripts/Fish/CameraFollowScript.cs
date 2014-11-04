using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    //The target for the camera to follow
    public GameObject Target;

    //the offset between the target and the camera
    private Vector3 offset;

	void Start () {
        //determine the offset between the fish and the camera
        offset = this.gameObject.transform.position - Target.gameObject.transform.position;
	}
	
	
	void LateUpdate () {
        //maintain the offset between the fish and the camera
        this.transform.position = Target.transform.position + offset;
	}
}

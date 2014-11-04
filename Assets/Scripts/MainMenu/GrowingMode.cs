using UnityEngine;
using System.Collections;

public class GrowingMode : MonoBehaviour {




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showLevels()
	{
		animation ["GrowingMode"].speed = 1;
		animation ["GrowingMode"].time = 0;
		animation.Play ();
	}

	public void HideLevels(GameObject mainMenu)
	{
		animation ["GrowingMode"].speed = -1;
		animation ["GrowingMode"].time = animation ["GrowingMode"].length;
		animation.Play ();

		mainMenu.SetActive(true);
	}
}

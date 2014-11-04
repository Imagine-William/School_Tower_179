using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void start()
	{

	}

	public void showMenu()
	{
		gameObject.SetActive(true);
	}

	public void hideMenu()
	{
		gameObject.SetActive(false);
	}
}

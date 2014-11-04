using UnityEngine;
using System.Collections;

public class InstructionPanel : MonoBehaviour {
	
	public void showInstructionsPanel()
	{
		gameObject.SetActive(true);
	}
	
	public void hideInstructionsPanel()
	{
		gameObject.SetActive(false);
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomizeShaderColor : MonoBehaviour {

    //a list of acceptable colors to choose from
    public Color[] AcceptableColors;

	void Start () {
        //change this game objects shader color to a random color from our list of acceptable colors
        gameObject.renderer.material.color = AcceptableColors[Random.Range(0, AcceptableColors.Length)];
	}
	
}

using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour 
{
	
	public Sprite layer_orange, layer_red;


	void OnMouseDown ()
	{
		GetComponent <SpriteRenderer> ().sprite = layer_red;
	}

	void OnMouseUp ()
	{
		GetComponent <SpriteRenderer> ().sprite = layer_orange;
	}

	void OnMouseUpAsButton () 
	{
		switch (gameObject.name) 
		{
		case "Play":
			Application.LoadLevel ("play");
			break;
		case "Rating":
			Application.OpenURL ("http://google.com");
			break;
		}
	}
}

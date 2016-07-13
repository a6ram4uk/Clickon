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
			Application.OpenURL ("http://vk.com/a6ram4uk");
			break;

		case "Replay":
			Application.LoadLevel ("play");
			break;

		case "Home":
			Application.LoadLevel ("main");
			break;

		case "How To":
			Application.LoadLevel ("howTo");
			break;

		case "Close":
			Application.LoadLevel ("main");
			break;
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameCntrl : MonoBehaviour 
{
	public GameObject pLost;

	public GameObject colBlock;
	public Vector3 [] positions;
	private GameObject block;
	private GameObject [] blocks = new GameObject[4];

	private int rand, count;
	private float rCol, gCol, bCol;
	public Text score;
	private static Color aColor;

	[HideInInspector]
	public bool next, lose;

	void Start () 
	{
		count = 0;
		next = false;
		lose = false;
		rand = Random.Range (0, positions.Length);
		for (int i = 0; i < positions.Length; i++) 
		{
			blocks [i] = Instantiate (colBlock, positions[i], Quaternion.identity) as GameObject;
			if (rand == i)
				block = blocks [i];
		}
		block.GetComponent <RandCol> ().right = true;
	}

	void Update () 
	{
		if (lose)
			playerLose ();
		if (next && !lose)
			nextColors ();
	}

	void nextColors () 
	{
		if (PlayerPrefs.GetString ("Music") != "no")
			GetComponent <AudioSource> ().Play ();
		count++;
		score.text = count.ToString ();
		aColor = new Vector4 (Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 1);
		GetComponent <Renderer> ().material.color = aColor;
		next = false;

		if (count < 3) 
		{
			rCol = 1.0f;
			gCol = 1.0f;
			bCol = 1.0f;
		}

		else if (count >= 3 && count < 6) 
		{
			rCol = 0.9f;
			gCol = 0.9f;
			bCol = 0.9f;
		}

		else if (count >= 6 && count < 9) 
		{
			rCol = 0.8f;
			gCol = 0.8f;
			bCol = 0.8f;
		}

		else if (count >= 9 && count < 12) 
		{
			rCol = 0.7f;
			gCol = 0.7f;
			bCol = 0.7f;
		}

		else if (count >= 12 && count < 15) 
		{
			rCol = 0.6f;
			gCol = 0.6f;
			bCol = 0.6f;
		}

		else if (count >= 15 && count < 18) 
		{
			rCol = 0.5f;
			gCol = 0.5f;
			bCol = 0.5f;
		}

		else if (count >= 18 && count < 21) 
		{
			rCol = 0.4f;
			gCol = 0.4f;
			bCol = 0.4f;
		}

		else if (count >= 21 && count < 24) 
		{
			rCol = 0.3f;
			gCol = 0.3f;
			bCol = 0.3f;
		}

		else if (count >= 24 && count < 27) 
		{
			rCol = 0.2f;
			gCol = 0.2f;
			bCol = 0.2f;
		}

		else if (count >= 27 && count < 30) 
		{
			rCol = 0.1f;
			gCol = 0.1f;
			bCol = 0.1f;
		}

		else if (count >= 30) 
		{
			rCol = 0.05f;
			gCol = 0.05f;
			bCol = 0.05f;
		}

		// New colors for blocks
		rand = Random.Range (0, positions.Length);
		for (int i = 0; i < positions.Length; i++)
		{
			if (i == rand)
				blocks [i].GetComponent <Renderer> ().material.color = aColor;
			else
			{
				float r = aColor.r + Random.Range (0.1f, rCol) > 1f ? 1f : aColor.r + Random.Range (0.1f, rCol);
				float g = aColor.g + Random.Range (0.1f, gCol) > 1f ? 1f : aColor.g + Random.Range (0.1f, gCol);
				float b = aColor.b + Random.Range (0.1f, bCol) > 1f ? 1f : aColor.b + Random.Range (0.1f, bCol);
				blocks [i].GetComponent <Renderer> ().material.color = new Vector4 (r, g, b, aColor.a);
			}
		}
	}

	void playerLose ()
	{
		if (PlayerPrefs.GetInt ("Score") < count)
		PlayerPrefs.SetInt ("Score", count);
		pLost.SetActive (true);

		if (PlayerPrefs.GetString ("Music") == "no")
			pLost.GetComponent <AudioSource> ().mute = true;
	}
}
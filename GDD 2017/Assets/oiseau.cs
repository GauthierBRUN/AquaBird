using UnityEngine;
using System.Collections;

public class oiseau : MonoBehaviour 
{
	float vitesse = 0.1f;
	int x = 0;

	// Use this for initialization
	void Start () 
	{

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (0,vitesse*x,0);
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(0,0,1);
			x++;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Rotate(0,0,-1);
			x--;
		}
	
	}


}

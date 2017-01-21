using UnityEngine;
using System.Collections;

public class oiseau2 : MonoBehaviour 
{

	public oiseau script;


	void Start () 
	{

	}

	void OnCollisionStay (Collision c)
	{
		if (c.gameObject.tag == "limite") 
		{
		
			script.addsc = 0;
	
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "eau") 
		{
			script.vitesse = script.vitesse / 2;
		}
		if (c.gameObject.tag == "obstacle") 
		{
			script.axey=script.axey-5;
		}
	}
	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "eau") 
		{
			script.vitesse = script.vitesse * 2;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		


		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.Rotate (0, 0, 1);
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			transform.Rotate (0, 0, -1);
		}

	
	}

}

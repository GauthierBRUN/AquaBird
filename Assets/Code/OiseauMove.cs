using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OiseauMove : MonoBehaviour 
{
	public float vitesse = 0.1f;
	public int axey = 0;


	// Use this for initialization
	void Start () 
	{
        	
	}

	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (0, Time.deltaTime * vitesse * axey, 0);
		if (Input.GetKey(KeyCode.DownArrow))
		{
			axey++;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			axey--;
		}	
	}





}

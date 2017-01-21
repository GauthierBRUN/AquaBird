using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class oiseau : MonoBehaviour 
{
	public float score = 0f;
	public int score2 ;
	public float vitesse = 0.01f;
	public int axey = 0;
	public float addsc =0.2f;
	public float score3=0f;
	public int score4;

	// Use this for initialization
	void Start () 
	{

	
	}

	
	// Update is called once per frame
	void Update () 
	{
		score = score + addsc;
		score2 = (int)score;
		score4 = (int)score3;
		score3= score3+addsc;
		if (score3>61f)
		{
			score3=0f;
		}


		transform.Translate (0,vitesse*axey,0);
		if (Input.GetKey(KeyCode.DownArrow))
		{
			axey++;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			axey--;
		}
		if (score > 300) 
		{
			score =score + 2*addsc ;
		}
		if (score > 600) 
		{
			score = score + 3*addsc;
		}
	
	}





}

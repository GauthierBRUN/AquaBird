using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newennemi : MonoBehaviour {
	float trime=0f;

	public oiseau script;
	public GameObject ennemi1;
	public GameObject ennemi2;
	public GameObject ennemi3;
	public GameObject ennemi4;
	public GameObject ennemi5;

	public GameObject ptdepop1;
	public GameObject ptdepop2;
	public GameObject ptdepop3;

	int x;
	public int y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (script.score4==60)
		{
			trime=trime+Time.deltaTime;
			x=Random.Range(1,6);
			if (trime>=0.1f)
			{
				y=x;
				trime=0f;
			}
			
		}

		if(y==1)
		{
			Instantiate(ennemi1,ptdepop1.transform.position,ptdepop1.transform.rotation);
			y=0;
			
		}
		if(y==2)
		{
			Instantiate(ennemi2,ptdepop1.transform.position,ptdepop1.transform.rotation);
			y=0;
			
		}
		if(y==3)
		{
			Instantiate(ennemi3,ptdepop3.transform.position,ptdepop1.transform.rotation);
			y=0;
			
		}
		if(y==4)
		{
			Instantiate(ennemi4,ptdepop2.transform.position,ptdepop1.transform.rotation);
			y=0;
			
		}
		if(y==5)
		{
			Instantiate(ennemi5,ptdepop1.transform.position,ptdepop1.transform.rotation);
			y=0;
			
		}

	}
}

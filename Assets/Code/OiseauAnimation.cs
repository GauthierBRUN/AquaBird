using UnityEngine;
using System.Collections;

public class OiseauAnimation : MonoBehaviour 
{
	public OiseauMove MoveComponent;
    public bool splash;
    public bool DansLeau;
    float rotatintense = 0f;
    public float vitessetourne = 25f;

    void Start () 
	{

	}



	void OnCollisionStay (Collision c)
	{
		if (c.gameObject.tag == "limite") 
		{
            var score =  GameObject.FindObjectsOfType<Gauthier.Score>();
			if (score.Length > 0)
            {
                score[0].GameFinished = true;
            }	
		}
		MoveComponent.axey = 0;

	}
	void OnCollisionEnter (Collision c)
	{
		transform.Rotate(0,0,-rotatintense);
		rotatintense=0f;
	}
	

	void OnTriggerEnter(Collider c)
	{
        if (c.gameObject.tag == "eau")
        {
            MoveComponent.vitesse = MoveComponent.vitesse / 2;
            splash = true;
        }
        if (c.gameObject.tag == "obstacle")
        {
            MoveComponent.axey = MoveComponent.axey - 5;
            transform.Rotate (0,0,-vitessetourne*5*Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "eau") 
		{
			MoveComponent.vitesse = MoveComponent.vitesse * 2;
            splash = false;
            DansLeau = false;
        }
	}

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "eau")
        {
            DansLeau = true;
            //splash = false;
        }
    }

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.Rotate (0, 0, vitessetourne*Time.deltaTime);
			rotatintense=rotatintense+vitessetourne*Time.deltaTime;
			
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			transform.Rotate (0, 0, -vitessetourne*Time.deltaTime);
			rotatintense=rotatintense+vitessetourne*-Time.deltaTime;
			
		}	
	}

}

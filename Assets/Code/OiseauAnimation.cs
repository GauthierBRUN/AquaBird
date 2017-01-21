using UnityEngine;
using System.Collections;

public class OiseauAnimation : MonoBehaviour 
{
	public OiseauMove MoveComponent;

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
	}

	void OnTriggerEnter(Collider c)
	{
        if (c.gameObject.tag == "eau")
        {
            MoveComponent.vitesse = MoveComponent.vitesse / 2;
        }
        if (c.gameObject.tag == "obstacle")
        {
            MoveComponent.axey = MoveComponent.axey - 5;
        }
    }

    void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "eau") 
		{
			MoveComponent.vitesse = MoveComponent.vitesse * 2;
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

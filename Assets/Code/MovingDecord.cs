using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDecord : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);
        
        if (transform.position.x < -250.0f)
        {
            Destroy(this.gameObject);
        }
	}
}

using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	public oiseau script;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<TextMesh> ().text = "Score : " + script.score2;
	
	}
}

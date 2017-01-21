using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	[FMODUnity.EventRef]
	public string BirdTheme;


	[FMODUnity.EventRef]
	public string Plouf;

	public OiseauAnimation oiseau;

	FMOD.Studio.EventInstance _birdtheme;
	FMOD.Studio.EventInstance _plouf;

	//public oiseau2 splash;
	bool dansLeau = false;

	void Start () 
	{
		_birdtheme = FMODUnity.RuntimeManager.CreateInstance (BirdTheme);
		_plouf = FMODUnity.RuntimeManager.CreateInstance (Plouf);
		_birdtheme.start ();		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (oiseau.splash && dansLeau == false)
		{
			_plouf.start ();
			dansLeau = true;
			Debug.Log ("splash");
		}

		if (!oiseau.splash && dansLeau)
		{
			dansLeau = false;
		}
	}
}

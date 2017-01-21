using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	[FMODUnity.EventRef]
	public string BirdTheme;


	[FMODUnity.EventRef]
	public string Plouf;

    [FMODUnity.EventRef]
    public string Intro;



    public OiseauAnimation oiseau;
    public GameObject ScreenDepart;

	FMOD.Studio.EventInstance _birdtheme;
	FMOD.Studio.EventInstance _plouf;
    FMOD.Studio.EventInstance _intro;

    FMOD.Studio.ParameterInstance _water;

	//public oiseau2 splash;
	bool ploufdansLeau = false;
     

	void Start () 
	{
		_birdtheme = FMODUnity.RuntimeManager.CreateInstance (BirdTheme);
		_plouf = FMODUnity.RuntimeManager.CreateInstance (Plouf);
        _intro = FMODUnity.RuntimeManager.CreateInstance(Intro);
        
        _intro.start();
        _birdtheme.getParameter("water", out _water);
        _water.setValue(0);
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKey(KeyCode.Space))
        {
            ScreenDepart.SetActive(false);
            _intro.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            _birdtheme.start ();
        }
        if (oiseau.splash && ploufdansLeau == false)
		{
			_plouf.start ();
			ploufdansLeau = true;
			Debug.Log ("splash");
		}

		if (!oiseau.splash && ploufdansLeau)
		{
			ploufdansLeau = false;
		}
        //Quand l'oiseau est dans l'eau
        if (oiseau.DansLeau)
        {
            _water.setValue(0.5f);
        }
        else if (!oiseau.DansLeau)
        {
            _water.setValue(0.0f);
        }
	}
}

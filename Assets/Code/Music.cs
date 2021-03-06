﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	[FMODUnity.EventRef]
	public string BirdTheme;


	[FMODUnity.EventRef]
	public string Plouf;


    [FMODUnity.EventRef]
    public string mort;

    [FMODUnity.EventRef]
    public string Intro;

    [FMODUnity.EventRef]
    public string sortieEau;

    public OiseauAnimation oiseau;
    public GameObject ScreenDepart;
    public GameObject Fleche;

	FMOD.Studio.EventInstance _birdtheme;
	FMOD.Studio.EventInstance _plouf;
    FMOD.Studio.EventInstance _intro;
    FMOD.Studio.EventInstance _sortieEau;
    FMOD.Studio.EventInstance _mort;

    FMOD.Studio.ParameterInstance _water;
     

	void Start () 
	{
		_birdtheme = FMODUnity.RuntimeManager.CreateInstance (BirdTheme);
		_plouf = FMODUnity.RuntimeManager.CreateInstance (Plouf);
        _intro = FMODUnity.RuntimeManager.CreateInstance(Intro);
        _sortieEau = FMODUnity.RuntimeManager.CreateInstance(sortieEau);
        _mort = FMODUnity.RuntimeManager.CreateInstance(mort);

        _intro.start();
        _birdtheme.getParameter("water", out _water);
        _water.setValue(0);
	}

    public void PlayStartGame()
    {
        _intro.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        _birdtheme.start();
    }

    public void PlayEndGame()
    {
        _mort.start();
        _birdtheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }


	// Update is called once per frame
	void Update () 
	{
        if (oiseau.IsInWater &&  !oiseau.HasWaterTransitionBeenPlayed)
		{
			_plouf.start ();
            Debug.Log("plouf");
            oiseau.HasWaterTransitionBeenPlayed = true;
		}
		else if (!oiseau.IsInWater && !oiseau.HasWaterTransitionBeenPlayed)
		{
            oiseau.HasWaterTransitionBeenPlayed = true;
            _sortieEau.start();

		}

        //Quand l'oiseau est dans l'eau
        if (oiseau.IsInWater)
        {
            _water.setValue(0.5f);
        }
        else
        {
            _water.setValue(0.0f);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecordSpawner : MonoBehaviour
{
    public MovingDecord DecordModel;
    public float DecordSpeed;
    public Vector3 SpawnLocation;
    public float SpawnInterval;

    public bool IsRandom;
    public float verticalRange;
    public float timeRange;

    private float TimeToNextSpawn;

	// Use this for initialization
	void Start () {
        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
        TimeToNextSpawn -= Time.deltaTime;

        if (TimeToNextSpawn < 0)
        {
            Spawn();
        }
	}

    void Spawn()
    {
        var newDecord = Instantiate(DecordModel);
        newDecord.Speed = DecordSpeed;
        newDecord.isOriginal = false;

        if (!IsRandom)
        {
            newDecord.transform.position = SpawnLocation;
            TimeToNextSpawn = SpawnInterval;
        }
        else
        {
            newDecord.transform.position = SpawnLocation + new Vector3(0, (Random.value * 2 - 1) * verticalRange);
            TimeToNextSpawn = SpawnInterval + (Random.value * 2 - 1) * timeRange;
        }
    }

    

}

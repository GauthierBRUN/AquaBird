using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecordSpawner : MonoBehaviour
{
    public MovingDecord DecordModel;
    public float DecordSpeed;
    public Vector3 SpawnLocation;
    public float SpawnInterval;

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
        newDecord.transform.position = SpawnLocation;
        newDecord.Speed = DecordSpeed;
        TimeToNextSpawn = SpawnInterval;
    }

    

}

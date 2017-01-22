using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gauthier
{
    public class Spawner : MonoBehaviour
    {

        public Obstacle SpawnedObject;

        public float InitialSpeedOfSpawned;
        public float SpawnX;
        public float MinimalSpawnHeight;
        public float MaximalSpawnHeight;

        public float MinimalTimeInterval;
        public float TimeToNextSpawn;

        public float Lambda;

        // Use this for initialization
        void Start()
        {
            TimeToNextSpawn = GenerateTimeToNextSpawn();
        }

        // Update is called once per frame
        void Update()
        {
            TimeToNextSpawn -= Time.deltaTime;

            if (TimeToNextSpawn < 0)
            {
                SpawnObject();
                TimeToNextSpawn = GenerateTimeToNextSpawn();
            }
        }

        void SpawnObject()
        {
            if (Score.IsGameRunning)
            {
                var newFoudre = Instantiate(SpawnedObject);
                newFoudre.HorizontalSpeed = InitialSpeedOfSpawned;
                newFoudre.transform.position = new Vector3(SpawnX, MinimalSpawnHeight + Random.value * (MaximalSpawnHeight - MinimalSpawnHeight), 0);
            }
        }

        float GenerateTimeToNextSpawn()
        {
            float rand = Random.value;
            float res = (MinimalTimeInterval * (1 + rand)) / (Score.SpawnSpeed + 0.1f);
            return res;
        }

    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gauthier
{
    public class Score : MonoBehaviour
    {
        private TextMesh ScoreText;
        public Text ScreenDepart;

        private float ScoreCoefficient;
        public float FixedUpdateScoreCoeffIncrement;
        public float ScoreValue;
        
        public OiseauAnimation Bird;
      
        static public bool IsGameRunning;

        private Music musicController;

        public GameObject Fleches;

        public static float SpawnSpeed;

        // Use this for initialization
        void Start()
        {
            var score = GameObject.FindObjectsOfType<Music>();
            if (score.Length > 0)
            {
                musicController = score[0];
            }

            ScoreText = GetComponent<TextMesh>();
            IsGameRunning = false;
            SpawnSpeed = 1;
        }

        // Update is called once per frame
        void Update()
        {
            ScoreText.text = ScoreValue.ToString("0.") + " pts";
            if (!IsGameRunning && Input.GetKey(KeyCode.Space))
            {
                StartGame();
            }
        }

        private void FixedUpdate()
        {
            if (IsGameRunning)
            {
                ScoreCoefficient += FixedUpdateScoreCoeffIncrement;
                ScoreValue += ScoreCoefficient * Time.fixedDeltaTime;
                SpawnSpeed = 1 + Mathf.Log(10) / Mathf.Log(ScoreValue + 1);
            }
        }


        public void StartGame()
        {
            ScoreCoefficient = 0;
            ScoreValue = 0;
            IsGameRunning = true;
            ScreenDepart.text = "";
            Bird.Rebird();
            musicController.PlayStartGame();
            Fleches.SetActive(false);
            SpawnSpeed = 1.0f;
        }

        public void EndGame()
        {
            if (IsGameRunning)
            {
                IsGameRunning = false;
                ScreenDepart.text = "Game Over";
                musicController.PlayEndGame();
                Fleches.SetActive(true);
                Bird.IsAlive = false;
            }
        }

    }
}

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
      
        public bool IsGameRunning;

        private Music musicController;

        public GameObject Fleches;

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
        }

        public void EndGame()
        {
            IsGameRunning = false;
            ScreenDepart.text = "Game Over";
            musicController.PlayEndGame();
            Fleches.SetActive(true);
        }

    }
}

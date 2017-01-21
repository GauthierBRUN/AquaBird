using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gauthier
{
    public class Score : MonoBehaviour
    {
        public Text ScoreText;
        private float ScoreCoefficient;
        public float FixedUpdateScoreCoeffIncrement;
        public float ScoreValue;

        public bool GameFinished;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ScoreText.text = ScoreValue + " pts";
        }

        private void FixedUpdate()
        {
            if (!GameFinished)
            {
                ScoreCoefficient += FixedUpdateScoreCoeffIncrement;
                ScoreValue += ScoreCoefficient * Time.fixedDeltaTime;
            }
        }
    }
}

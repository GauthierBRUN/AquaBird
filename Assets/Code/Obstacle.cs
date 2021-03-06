﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gauthier
{
    public class Obstacle : MonoBehaviour
    {
        public float HorizontalSpeed;
        public float VerticalAmplitude;

        public float HorizontalLimit = -100.0f;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

            transform.Translate(-Time.deltaTime * HorizontalSpeed, VerticalAmplitude * Mathf.Cos(Time.time), 0);

            if (transform.position.x < HorizontalLimit)
            {
                Destroy(this.gameObject);
            }
        }

        
    }
}

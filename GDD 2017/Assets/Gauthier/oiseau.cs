using UnityEngine;
using System.Collections;

namespace Gauthier
{
    public class oiseau : MonoBehaviour
    {

        private static readonly float Vitesse = 0.1f;


        private Rigidbody myBody;

        // Use this for initialization
        void Start()
        {
            myBody = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 transalation = Vitesse * InLocalBase(new Vector3(0, Mathf.Sin(transform.rotation.z), 0));
            transform.Translate(transalation);

            myBody.AddForce(transalation);

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, -1);
            }

        }

        Vector3 InLocalBase(Vector3 v)
        {
            var alpha = transform.rotation.z;
            return new Vector3(v.x * Mathf.Cos(alpha) + v.y * Mathf.Sin(alpha), v.x * Mathf.Sin(alpha) + v.y * Mathf.Cos(alpha), 0);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                Debug.Log("Game over");
            }
        }

    }
}

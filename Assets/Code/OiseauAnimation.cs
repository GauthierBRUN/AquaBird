using UnityEngine;
using System.Collections;

public class OiseauAnimation : MonoBehaviour 
{
	public GameObject MoveComponent;

    public float MaximumVerticalSpeed;
    public float RotationSpeed;
    public float MaximumVerticalAngleTop;
    public float MaximumVerticalAngleBottom;

    public bool HasWaterTransitionBeenPlayed;
    public bool IsInWater;

    void Start () 
	{

	}

    void Update()
    {        
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            LocalRotate(RotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            LocalRotate(- RotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        MoveComponent.transform.Translate(0, Time.fixedDeltaTime * ComputeVerticalSpeed(), 0);
    }

    void OnCollisionStay (Collision c)
	{
		if (c.gameObject.tag == "limite") 
		{
            var score =  GameObject.FindObjectsOfType<Gauthier.Score>();
			if (score.Length > 0)
            {
                score[0].GameFinished = true;
            }	
		}
	}

	void OnCollisionEnter (Collision c)
	{

	}
	

	void OnTriggerEnter(Collider c)
	{
        switch (c.gameObject.tag)
        {
            case "eau":
                IsInWater = true;
                HasWaterTransitionBeenPlayed = false;
                break;
            case "obstacle":
                break;
            default:
            break;
        }
    }

    void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "eau") 
		{
            IsInWater = false;
            HasWaterTransitionBeenPlayed = false;
        }
	}

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "eau")
        {
            IsInWater = true;
        }
    }

    float ComputeVerticalSpeed()
    {
        return MaximumVerticalSpeed * Mathf.Sin(transform.rotation.z);
    }


    void LocalRotate (float z)
    {
        float zafaterRotation = z + transform.rotation.z *180 / Mathf.PI;
        if (zafaterRotation < MaximumVerticalAngleTop && zafaterRotation > MaximumVerticalAngleBottom)
        {
            transform.Rotate(0, 0, z);
        }
    }

}

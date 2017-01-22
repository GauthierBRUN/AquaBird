using UnityEngine;
using System.Collections;

public class OiseauAnimation : MonoBehaviour 
{
	public GameObject MoveComponent;

    private Vector3 StartPosition;
    private Vector3 StartPositionInner;
    private Quaternion StarttRotation;

    public float AirVerticalSpeed;
    public float WaterVerticalSpeed;

    public float RotationSpeed;
    public float MaximumVerticalAngleTop;
    public float MaximumVerticalAngleBottom;


    public bool HasWaterTransitionBeenPlayed;
    public bool IsInWater;

    public bool IsAlive;

    private Gauthier.Score scoreComponent;

    void Start ()
    {
        var score = GameObject.FindObjectsOfType<Gauthier.Score>();
        if (score.Length > 0)
        {
            scoreComponent = score[0];
        }

        StartPosition = MoveComponent.transform.position;
        StarttRotation = transform.rotation;
        StartPositionInner = transform.position;
        IsAlive = true;
    }

    void Update()
    {
        if (!IsAlive)
        {
            LocalRotate(-RotationSpeed * Time.deltaTime);
            return;
        }

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
            scoreComponent.EndGame();
            IsAlive = false;
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
                scoreComponent.EndGame();
                IsAlive = false;
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
        if (IsInWater)
        {
            return WaterVerticalSpeed * Mathf.Sin(transform.rotation.z);
        }
        else
        {
            return AirVerticalSpeed * Mathf.Sin(transform.rotation.z);
        }  
    }


    void LocalRotate (float z)
    {
        float zAfterRotation = z + transform.rotation.z *180 / Mathf.PI;
        if (zAfterRotation < MaximumVerticalAngleTop && zAfterRotation > MaximumVerticalAngleBottom)
        {
            transform.Rotate(0, 0, z);
        }
    }

    public void Rebird()
    {
        IsAlive = true;
        MoveComponent.transform.position = StartPosition;
        transform.rotation = StarttRotation;
        transform.position = StartPositionInner;
    }

}

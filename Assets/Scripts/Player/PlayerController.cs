using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

	public float movSpeed = 1.5f;

	private Rigidbody2D rigidBody2D;
	private Transform player_root_transform; //move player based on root transform, save computing?

	private Vector3 offsetVec;




	Matrix4x4 calibrationMatrix;
	Vector3 wantedDeadZone  = Vector3.zero;

	//Finally how you get the accelerometer input
	Vector3 _InputDir;

	void Start()
	{
		rigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
		player_root_transform = transform.root.transform;
		CalibrateOffset ();
	
	}

	void Update ()
	{
		CalibrateOffset ();
	}


	void FixedUpdate ()
	{
		_InputDir = getAccelerometer(Input.acceleration);
		//then in your code you use _InputDir instead of Input.acceleration for example 
//		transform.Translate (_InputDir.x, 0, -_InputDir.z);
		rigidBody2D.velocity = new Vector3 (_InputDir.x * movSpeed, _InputDir.y * movSpeed, 0f);



	
//		rigidBody2D.velocity = new Vector3 ((Input.acceleration.x - offsetVec.x) * movSpeed, (Input.acceleration.y - offsetVec.y) * movSpeed);
//		Debug.Log ("RawX " + Input.acceleration.x + ", RawY " + Input.acceleration.y);

		float heading = Mathf.Atan2 (Input.acceleration.x, Input.acceleration.y);

		//Debug.Log ("X acceleration: " + Input.acceleration.x + " Y acccleration: " + Input.acceleration.y);
		//Debug.Log ("heading: " + heading);

		//need to make negative to fix side rotation
		//player_root_transform.rotation = Quaternion.Euler (0f, 0f, - heading * Mathf.Rad2Deg);

	}

	void CalibrateOffset ()
	{
		if (CrossPlatformInputManager.GetButton ("OffsetButton"))
		{
//			offsetVec.x = Input.acceleration.x;
//			offsetVec.y = Input.acceleration.y;
//			offsetVec.z = 0f;
			calibrateAccelerometer();
		}
	}



	//Method for calibration 
	void calibrateAccelerometer()
	{
		wantedDeadZone = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), wantedDeadZone);
		//create identity matrix ... rotate our matrix to match up with down vec
		Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));
		//get the inverse of the matrix
		calibrationMatrix = matrix.inverse;

	}

	//Method to get the calibrated input 
	Vector3 getAccelerometer(Vector3 accelerator){
		Vector3 accel = this.calibrationMatrix.MultiplyVector(accelerator);
		return accel;
	}
		
}
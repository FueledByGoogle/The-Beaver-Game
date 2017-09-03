using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

	public float movSpeed = 2f;

	private Camera main_camera;
	private Transform player_root_transform; //move player based on root transform,
											 //possibly better than using transform.root each time? Less calculations.
	private Rigidbody2D rigidBody;

	void Start ()
	{
//		main_camera = Camera.main; //use when you want camera to follow player
		player_root_transform = transform.root.transform;
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		Movement ();
	}

	private void Movement ()
	{
		
		Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));

		if (movement.x != 0 && movement.y != 0) { //prevents rotation from being reset.
			float heading = Mathf.Atan2 (movement.x, movement.y);
			player_root_transform.rotation = Quaternion.Euler (0f, 0f, - heading * Mathf.Rad2Deg); //need to make negative to fix side rotation
		}
		//horizontal movement
		if (movement.x != 0) {
			if (movement.x > 0) {
				rigidBody.velocity = new Vector3 (movSpeed * movement.x, rigidBody.velocity.y, 0f);
			} else {
				rigidBody.velocity = new Vector3 (movSpeed * movement.x, rigidBody.velocity.y, 0f);
			}
		} else {
			rigidBody.velocity = new Vector3 (0f, rigidBody.velocity.y, 0f);
		}
		//vertical movement
		if (movement.y != 0) {
			if (movement.y > 0) {
				rigidBody.velocity = new Vector3 (rigidBody.velocity.x, movSpeed * movement.y, 0f);
			} else {
				rigidBody.velocity = new Vector3 (rigidBody.velocity.x, movSpeed * movement.y, 0f);
			}
		} else {
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, 0f, 0f);
		}


		//use when you want camera to follow player
//		main_camera.transform.eulerAngles = new Vector3(0f, 0f, 0f); //freeze camera rotation
		//		main_camera.transform.position = new Vector3 (player_root_transform.position.x, player_root_transform.position.y, main_camera.transform.position.z);

	}


}

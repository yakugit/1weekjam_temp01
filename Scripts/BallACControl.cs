using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Ball;

public class BallACControl : MonoBehaviour {

	private Ball ball; // Reference to the ball controller.

	private Vector3 move;
	// the world-relative desired move direction, calculated from the camForward and user input.

	private Transform cam; // A reference to the main camera in the scenes transform
	private Vector3 camForward; // The current forward direction of the camera
	private bool jump; // whether the jump button is currently pressed

	Vector3 velocity;

	Rigidbody rb;

	public Transform RollBallLookAt;

	public Text TimeText;

	bool TimerStarted;

	public float PlayTime = 0;
	float LastTextTime = 0;

	public AudioSource MoveAudio;
	public float AudioLimit = 2f;

	private void Awake()
	{
		// Set up the reference.
		ball = GetComponent<Ball>();

		rb = GetComponent<Rigidbody> ();

		// get the transform of the main camera
		if (Camera.main != null)
		{
			cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			// we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
		}
	}

	void Start (){
		TimeText.text = LastTextTime.ToString ();
	}


	private void Update()
	{
		if (TimerStarted && enabled) {
			
			// Get the axis and jump input.

			float h = CrossPlatformInputManager.GetAxis ("Horizontal");
			float v = CrossPlatformInputManager.GetAxis ("Vertical");
			jump = false;

			// calculate move direction
			if (cam != null) {
				// calculate camera relative direction to move:
				camForward = Vector3.Scale (cam.forward, new Vector3 (1, 0, 1)).normalized;
				move = (v * camForward + h * cam.right).normalized;
			} else {
				// we use world-relative directions in the case of no main camera
				move = (v * Vector3.forward + h * Vector3.right).normalized;
			}

			PlayTime += Time.deltaTime;

			var volume = Mathf.InverseLerp (0, AudioLimit, rb.velocity.magnitude);
			volume = Mathf.Clamp (volume, 0f, 1f);
			MoveAudio.volume = volume;
		}

		if (LastTextTime != PlayTime) {
			LastTextTime = Mathf.Floor(PlayTime);
			TimeText.text = LastTextTime.ToString ();
		}
	}


	private void FixedUpdate()
	{
		// Call the Move function of the ball controller
		ball.Move(move, jump);
		jump = false;
	}

	public void StopInput() {
		enabled = false;

		ball.enabled = false;

		velocity = rb.velocity;

		rb.isKinematic = true;

		MoveAudio.Stop ();
		MoveAudio.volume = 0f;
	}

	public void StartInput() {
		enabled = true;

		ball.enabled = true;

		rb.velocity = velocity;

		rb.isKinematic = false;

		RollBallLookAt.rotation = Quaternion.LookRotation (velocity.normalized);

		MoveAudio.Play ();
		MoveAudio.volume = 0f;
	}

	public void StartTimer() {
		TimerStarted = true;

		MoveAudio.Play ();
		MoveAudio.volume = 0f;
	}
}

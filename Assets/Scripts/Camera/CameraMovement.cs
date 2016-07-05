using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class CameraMovement : MonoBehaviour {
	public float MaxZoomIn = 1f;
	public float MaxZoomOut = 10f;
	public float ZoomSpeed = 100f;
	public float MaxX = 10f;
	public float MinX = -10f;
	public float MaxY = 10f;
	public float MinY = -10f;
	public float XYSpeed = 10f;

	Camera cam;
	float vertical;
	float horizontal;
	Vector3 movementVector;
	// Use this for initialization
	void Start () {
		cam = GetComponent <Camera> ();
	}

	// Update is called once per frame
	void Update () {
		GetInputs ();
		Move ();
	}
	void GetInputs(){
		vertical = Input.GetAxisRaw ("Vertical");
		horizontal = Input.GetAxisRaw ("Horizontal");
	
	}
	void ZoomIn(){
		Debug.Log ("Zooming In");
		if(cam.orthographicSize > MaxZoomIn){
			cam.orthographicSize -= ZoomSpeed * Time.deltaTime;	
		}
	}
	void ZoomOut(){
		Debug.Log ("Zooming Out");
		if( cam.orthographicSize < MaxZoomOut){
			cam.orthographicSize += ZoomSpeed * Time.deltaTime;	
		}
	}
	void Move(){
		movementVector = new Vector3 (horizontal,vertical,0f);
		movementVector = movementVector.normalized * XYSpeed * Time.deltaTime;
		transform.Translate (movementVector);
	}

}

using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class CameraMovement : MonoBehaviour {
	public float MaxZoomIn = 1f;
	public float MaxZoomOut = 10f;
	public float ZoomSpeed = 0.5f;
	public float XYSpeed = 10f;

	Camera cam;
	float vertical;
	float horizontal;
	float InOut;
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
		InOut = Input.GetAxisRaw("Mouse ScrollWheel");
	}
	void ZoomIn(){
		Debug.Log ("Zooming In");
		if(cam.orthographicSize > MaxZoomIn){
			cam.orthographicSize -= ZoomSpeed ;	
		}
	}
	void ZoomOut(){
		Debug.Log ("Zooming Out");
		if( cam.orthographicSize < MaxZoomOut){
			cam.orthographicSize += ZoomSpeed ;	
		}
	}
	void Move(){
		if(InOut > 0f){
			ZoomIn();
		}
		if(InOut < 0f){
			ZoomOut();
		}
		if( cam.transform.position.x < MapInfo.MapLimits.xMin && horizontal < 0){
			horizontal = 0;
		}
		if( cam.transform.position.x > MapInfo.MapLimits.width && horizontal > 0){
			horizontal = 0;
		}
		if( cam.transform.position.z < MapInfo.MapLimits.yMin && vertical < 0){
			vertical = 0;
		}
		if( cam.transform.position.z > MapInfo.MapLimits.height && vertical > 0){
			vertical = 0;
		}

		movementVector = new Vector3 (horizontal,vertical,0f);
		movementVector = movementVector.normalized * XYSpeed * Time.deltaTime;
		transform.Translate (movementVector);
	}

}

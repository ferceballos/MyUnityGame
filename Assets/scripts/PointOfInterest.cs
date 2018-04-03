using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour {

	public Collider characterCollider;
	public Transform pointOfInterest;
	public Vector3 pointOffset;
	public CameraController cameraController;

	void Start()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other == characterCollider){
		cameraController.startWatchingPOI(this.pointOfInterest, this.pointOffset);
		}
	}

	void OnTriggerStay(Collider other)
	{

	}

	void OnTriggerExit(Collider other)
	{
		if (other == characterCollider){
			cameraController.stopWatchingPOI();
		}
	}

}

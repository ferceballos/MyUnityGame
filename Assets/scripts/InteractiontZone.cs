using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiontZone : MonoBehaviour
{
    public Collider characterCollider;
    public Transform interactionZone;
    public Vector3 interactionOffset;
    public CameraController cameraController;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other == characterCollider && Input.GetButtonDown("Fire3"))
        {
            print("lets faquin talk");
            cameraController.startWatchingIZ(interactionZone, interactionOffset);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

}

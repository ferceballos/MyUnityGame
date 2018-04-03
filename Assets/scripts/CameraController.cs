using UnityEngine;

public class CameraController : MonoBehaviour
{

    //character of the camera
    public Transform character;

    //General Camera Values
    public float smoothSpeed = 10f;
    public Vector3 offset;

    //Flags
    public bool watchingPOI = false;
    public bool watchingIZ = false;

    //Points of interest values
    public float rotationSpeed = 5f;
    public Transform pointOfInterest;
    public Vector3 pointOffset;

    //Interactive point
    public float interactiveRotationSpeed = 5f;
    public Transform interactivePoint;
    public Vector3 interactiveOffset;

    void Start()
    {
        transform.position = character.position + offset;
    }

    void FixedUpdate()
    {
        if (watchingPOI)
        {
            watchPoint();
        }

        else if (watchingIZ)
        {
            watchIZ();
        }

        else
        {
            watchPlayer();
        }

    }

    void watchPlayer()
    {
        Vector3 desiredPosition = character.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(character);
    }

    public void watchPoint()
    {
        Vector3 desiredPosition = pointOfInterest.position + pointOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, rotationSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        //transform.LookAt(pointOfInterest);
    }

    public void startWatchingPOI(Transform pointOfInterest, Vector3 pointOffset)
    {
        watchingPOI = true;
        this.pointOfInterest = pointOfInterest;
        this.pointOffset = pointOffset;
        var POIRotation = Quaternion.LookRotation(pointOfInterest.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, POIRotation, rotationSpeed * Time.deltaTime);
    }


    public void stopWatchingPOI()
    {
        var characterRotation = Quaternion.LookRotation((character.transform.position - transform.position));
        transform.rotation = Quaternion.Slerp(transform.rotation, characterRotation, rotationSpeed * Time.deltaTime);
        watchingPOI = false;
    }

    public void startWatchingIZ(Transform interactivePoint, Vector3 interactiveOffset)
    {
        watchingIZ = true;
        this.interactivePoint = interactivePoint;
        this.interactiveOffset = interactiveOffset;
        var IZRotation = Quaternion.LookRotation(interactivePoint.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, IZRotation, rotationSpeed * Time.deltaTime);
    }

    public void watchIZ()
    {
        var center = ((interactivePoint.position - character.position) / 2.0f) + character.position;
        Vector3 desiredPosition = center + interactiveOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, rotationSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(center);
    }
}
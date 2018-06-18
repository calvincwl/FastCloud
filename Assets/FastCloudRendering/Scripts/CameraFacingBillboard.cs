using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    Camera ReferenceCamera;

    public enum AxisType { Up, Down, Left, Right, Forward, Back };
    public bool ReverseFace = false;
    public AxisType Axis = AxisType.Up;

    // return a direction based upon chosen axis
    public Vector3 GetAxis(AxisType refAxis)
    {
        switch (refAxis)
        {
            case AxisType.Down:
                return Vector3.down;
            case AxisType.Forward:
                return Vector3.forward;
            case AxisType.Back:
                return Vector3.back;
            case AxisType.Left:
                return Vector3.left;
            case AxisType.Right:
                return Vector3.right;
        }

        // default is Vector3.up
        return Vector3.up;
    }

    void Awake()
    {
        // if no camera referenced, grab the main camera
        if (!ReferenceCamera)
            ReferenceCamera = Camera.main;
    }

    void Update()
    {
        // rotates the object relative to the camera
        var rotation = ReferenceCamera.transform.rotation;
        Vector3 targetPos = transform.position + rotation * (ReverseFace ? Vector3.forward : Vector3.back);
        Vector3 targetOrientation = rotation * GetAxis(Axis);
        transform.LookAt(targetPos, targetOrientation);
    }
}

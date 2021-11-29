using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dup_rotationCam : MonoBehaviour, IBeginDragHandler, IDragHandler
{
  // Start is called before the first frame update
  public Transform camPivot;
  public float rotationSpeed = 0.4f;

  Vector3 beginPos;
  Vector3 draggingPos;
  float xAngle;
  float yAngle;
  float xAngleTemp;
  float yAngleTemp;

  private void Start()
  {
    xAngle = camPivot.rotation.eulerAngles.x;
    yAngle = camPivot.rotation.eulerAngles.y;
  }

  public void OnBeginDrag(PointerEventData beginPoint)
  {
    beginPos = beginPoint.position;

    xAngleTemp = xAngle;
    yAngleTemp = yAngle;
  }

  public void OnDrag(PointerEventData draggingPoint)
  {
    draggingPos = draggingPoint.position;

    yAngle = yAngleTemp + (draggingPos.x - beginPos.x) * 180 / Screen.width * rotationSpeed;
    xAngle = xAngleTemp - (draggingPos.y - beginPos.y) * 90 / Screen.height * rotationSpeed;

    if (xAngle > 50) xAngle = 50;
    if (xAngle < -12) xAngle = -12;

    camPivot.rotation = Quaternion.Euler(xAngle, yAngle, 0.0f);
  }
}

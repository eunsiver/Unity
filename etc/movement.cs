//camera screen rotation, move 
//can't move object in the direction of camera view


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
  public float Yaxis;
  public float Xaxis;
  float RotationMin = -40f;
  float RotationMax = 80f;
  float smoothTime = 0.12f;
  public float RotationSensitivity = 8f;
  public Transform target;
  Vector3 targetRotation;
  Vector3 currentVel;

  public bool enableMoblieInput = false;
  public FixedTouch_panel touchField;
  
  private void Start()
  {
    //CamTransform = gameObject.transform;//
    if (enableMoblieInput)
      RotationSensitivity = 0.2f;
  }
  void LateUpdate()
  {
    if (enableMoblieInput)
    {
      Yaxis += touchField.TouchDist.x * RotationSensitivity;

      Xaxis -= touchField.TouchDist.y * RotationSensitivity;
    }
    else
    {
      Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
      Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
    }
    Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);

    targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);
    transform.eulerAngles = targetRotation;

    transform.position = target.position - transform.forward * 10f + new Vector3(0, 3f, 0f);
    
  }
}

//-------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyPlayer : MonoBehaviour


{
  public bool Grobal;
  public float MoveSpeed = 3f;
  private float smoothRotationTime = 0.2f;

  float currentVelocity;
  float currentSpeed;
  float speedVelocity;

  public Transform camPivot;

  public bool ennaleMoblieInput = false;
  public FixedJoystick joystick; //{ get; set; }



  private void Start()
  {
   
  }
  void Update()
  {
   
    Vector2 input = Vector2.zero;
    if (ennaleMoblieInput)
    {
      input = new Vector2(joystick.input.x, joystick.input.y);
     
    }
    else
    {
      input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    
    Vector2 inputDir = input.normalized;
    }
    if (inputDir != Vector2.zero)
    {
      float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
      transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
    }
    float targetSpeed = MoveSpeed * inputDir.magnitude;
    currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, 0.1f);

    if (Grobal) transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
    else transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.Self);
   
  }

}




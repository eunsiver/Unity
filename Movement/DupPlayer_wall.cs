using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dup_player : MonoBehaviour
{
  // Start is called before the first frame update
  public Transform moving_object;
  public float speed = 20f;
  public Transform camPivot;
  [SerializeField] private GameObject fixedJoystick;

  private Joystick controller;
  Vector3 position;
  [SerializeField] private GameObject parentCharacter;
  ///////
  public float Kspeed = 2F;
  public float rotationSpeed = 100.0F;

  private void Awake()
  {
    controller = fixedJoystick.GetComponent<Joystick>();
  }

  private void FixedUpdate()
  {
    Vector2 conDir = controller.Direction;
    if (conDir == Vector2.zero) return;

    float thetaEuler = Mathf.Acos(conDir.y / conDir.magnitude) * (180 / Mathf.PI) * Mathf.Sign(conDir.x);

    Vector3 moveAngle = Vector3.up * (camPivot.transform.rotation.eulerAngles.y + thetaEuler);
    moving_object.rotation = Quaternion.Euler(moveAngle);
    moving_object.Translate(Vector3.forward * Time.fixedDeltaTime * speed);

  }

  // private void Update()
  // {



  //   float translation = Input.GetAxis("Vertical") * Kspeed;
  //   float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
  //   // translation *= Time.deltaTime;
  //   // rotation *= Time.deltaTime;
  //   translation *= Time.deltaTime;
  //   rotation *= Time.deltaTime;
  //   transform.Translate(0, 0, translation);
  //   transform.Rotate(0, rotation, 0);
  //   if (translation != 0 && Joystick.Joystick_playing == 0)
  //   {
  //     LoadCharacter.Character_anim.Play();

  //   }
  //   else if (translation == 0 && Joystick.Joystick_playing == 0)
  //     LoadCharacter.Character_anim.Stop();
  // }
  public float Mouse_rot_speed = 5.0f;
  public float Joy_rot_speed = 2.0f;
  public float Joy_rot_speed_vertical = 1.0f;

  public Camera MainCamera;

  public float CameraMaxDistance = 5f;
  // float CameraZeroPointWidth = 0;
  // float CameraZeroPointHight = 3f;
  float camera_pitch;
  float mouseX;
  float mouseY;
  float RightHorizental;
  float RightVertical;
  RaycastHit hit;

  //Vector3 CameraZeroPosition;
  //private void Start()
  //{
  //    CameraZeroPosition = new Vector3(0, CameraZeroPointHight, CameraZeroPointWidth);
  //}
  private void Update()
  {

    float translation = Input.GetAxis("Vertical") * Kspeed;
    float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
    translation *= Time.deltaTime;
    rotation *= Time.deltaTime;
    transform.Translate(0, 0, translation);
    transform.Rotate(0, rotation, 0);
    if (translation != 0 && Joystick.Joystick_playing != 1)
    {
      LoadCharacter.Character_anim.Play();
    }
    else if (translation == 0 && Joystick.Joystick_playing != 1)
      LoadCharacter.Character_anim.Stop();


    Debug.DrawRay(transform.position, MainCamera.transform.position - transform.position, Color.red);
    Debug.DrawRay(transform.position, (MainCamera.transform.position - transform.position).normalized * CameraMaxDistance, Color.blue);

    if (Physics.Raycast(transform.position, (MainCamera.transform.position - transform.position).normalized, out hit, CameraMaxDistance))
    {
      if (hit.transform.gameObject.tag != "Player")
      {
        Vector3 add = new Vector3(0, 0, 0);

        if (MainCamera.transform.localPosition.y < 0.5)
        {
          add.y = 0.2f;
          MainCamera.transform.localPosition += add;
        }

        MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, MainCamera.transform.localPosition + Vector3.forward, Time.deltaTime * 10);
        MainCamera.transform.position = hit.point;
      }
    }
    else
    {
      float center_collider;
      int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

      if (selectedCharacter == 3)
      {
        center_collider = LoadCharacter.Character_collider.radius - 3.0f;
      }
      else center_collider = LoadCharacter.Character_collider.radius;
      MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, new Vector3(0, center_collider + 0.5f, -CameraMaxDistance), Time.deltaTime * 5f);
      //Debug.DrawRay(transform.position, MainCamera.transform.position, Color.red);     

    }

  }


}

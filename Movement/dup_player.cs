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

  void FixedUpdate()
  {
    Vector2 conDir = controller.Direction;
    if (conDir == Vector2.zero) return;

    float thetaEuler = Mathf.Acos(conDir.y / conDir.magnitude) * (180 / Mathf.PI) * Mathf.Sign(conDir.x);

    Vector3 moveAngle = Vector3.up * (camPivot.transform.rotation.eulerAngles.y + thetaEuler);
    moving_object.rotation = Quaternion.Euler(moveAngle);
    moving_object.Translate(Vector3.forward * Time.fixedDeltaTime * speed);

  }

  void Update()
  {
    float translation = Input.GetAxis("Vertical") * Kspeed;
    float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
    translation *= Time.deltaTime;
    rotation *= Time.deltaTime;
    transform.Translate(0, 0, translation);
    transform.Rotate(0, rotation, 0);
    if (translation != 0&&Joystick.Joystick_playing!=1)
    {
      LoadCharacter.Character_anim.Play();
    }
    else if(translation == 0&&Joystick.Joystick_playing!=1)
      LoadCharacter.Character_anim.Stop();
  }
}

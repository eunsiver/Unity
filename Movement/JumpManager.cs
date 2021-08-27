using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpManager : MonoBehaviour//,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler

{
  public Rigidbody rb;
  //GameObject ch;

  public bool IsJumping = false;
  void Start()
  {

    Rigidbody rb = GetComponent<Rigidbody>();
  }
  private void OnCollisionEnter(Collision collision)
  {
    Debug.Log("Hit");
    IsJumping = false;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
  public RectTransform pad;
  public Transform player;
  Vector3 moveForward;
  Vector3 moveRotate;
  public float moveSpeed;
  public float rotateSpeed;
  bool walking;

  void Start(){
    //Vector3 vec2 = player.transform.Position;
  }
  public void OnDrag(PointerEventData eventData)
  {
    transform.position = eventData.position;
    transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);

    moveForward = new Vector3(0, 0, transform.localPosition.y).normalized;
    moveRotate = new Vector3(0, transform.localPosition.x, 0).normalized;
    if (!walking)
    {
      walking = true;
      //player.GetComponent<Animator>().SetBool("Walk", true);
    }
  }
  public void OnPointerUp(PointerEventData eventData)
  {
    //손 땠을 때 원위치로 돌리기
    transform.localPosition = Vector3.zero;
    moveForward = Vector3.zero;
    moveRotate = Vector3.zero;
    StopCoroutine("PlayerMove");
    walking = false;
    //player.GetComponent<Animator>().SetBool("Walk", false);
  }
  public void OnPointerDown(PointerEventData eventData)
  {
    StartCoroutine("PlayerMove");
  }

  IEnumerator PlayerMove()
  {
    while (true)
    {
      player.Translate(moveForward * moveSpeed * Time.deltaTime);
      if (Mathf.Abs(transform.localPosition.x) > pad.rect.width * 0.3f)
        player.Rotate(moveRotate * rotateSpeed * Time.deltaTime);

      yield return null;
    }
  }
  // void StopToWall()
  // {
  //   Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
  // }
  // void FixedUpdate()
  // {
  //   StopToWall();
  // }
}

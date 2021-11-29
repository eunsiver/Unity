using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dup_Camera : MonoBehaviour
{
  // Start is called before the first frame update
  public Transform following_object;

  private void FixedUpdate()
  {
    Vector3 pos = this.transform.position;
    this.transform.position = Vector3.Lerp(pos, following_object.position, 1f);
    }
  }

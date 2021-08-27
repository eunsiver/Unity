using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
  public JumpManager jumpManager;
  public void Jump()
  {
    if (jumpManager.IsJumping == false)
    {
      jumpManager.IsJumping = true;
      jumpManager.rb.velocity += Vector3.up * 5f;
    }
  }
}
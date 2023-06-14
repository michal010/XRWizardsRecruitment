using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPlayerInput
{
    float HorizontalInput { get; }
    float VerticalInput { get; }
    bool MouseButtonZeroHold { get; }
    bool MouseButtonOneHold { get; }
    bool SpaceBarPressed { get; }
}


// Simple implementation of player's input, could be more expanded eg.
// Instead of receiving input from this class, there could be a hook method that'd re-hook actions based
// on given context, eg. -> player is using fork lift -> hook all forklift interactions

// Other solution would be to use new Unity's Input System, and smilillary -> hook adequate actions based on context.
public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public float HorizontalInput => Input.GetAxis("Horizontal");
    public float VerticalInput => Input.GetAxis("Vertical");
    public bool MouseButtonZeroHold => Input.GetMouseButton(0);
    public bool MouseButtonOneHold => Input.GetMouseButton(1);
    public bool SpaceBarPressed => Input.GetKeyDown(KeyCode.Space);

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInput : MonoBehaviour, IAgentInput
{
    public Vector2 MovementVector { get; private set; }

    public event Action<Vector2> OnMovement;

    [SerializeField] private MobileJoyStick joyStick;

    private void FixedUpdate()
    {
        joyStick.OnMove += Move;
    }

    private void Move(Vector2 input)
    {
        MovementVector = input;
        OnMovement?.Invoke(MovementVector);
    }
}

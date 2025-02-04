﻿using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    private ContinousMovement continousMovement;
    void Start()
    {
        character = GetComponent<CharacterController>();
        continousMovement = GetComponent<ContinousMovement>();
    }
    private void FixedUpdate()
    {
        if (climbingHand)
        {
            continousMovement.enabled = false;
            Climb();
        }
        else
        {
            continousMovement.enabled = true;
        }
    }
    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode)
            .TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        character.Move(transform.rotation*-velocity * Time.fixedDeltaTime);
    }
}

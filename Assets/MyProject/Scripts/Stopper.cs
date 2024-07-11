using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStopper
{
    void ActivateStopper();
    void DeactivateStopper();
}

public class Stopper : MonoBehaviour, IStopper
{
    [SerializeField] private Rigidbody2D _rigidBody;
    private float _mass;
    private void OnValidate()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _mass = _rigidBody.mass;
    }
   
    public void ActivateStopper()
    {
        _rigidBody.mass = _mass;
    }
    public void DeactivateStopper()
    {
        _rigidBody.mass = 0f;
    }
}

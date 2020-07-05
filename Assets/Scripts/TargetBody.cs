using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TargetBody : MonoBehaviour, IRigidObject
{
    private Rigidbody[] _rigidbodies;
    private Animator _animator;
    private bool isPhysics = true;

    private void Start() {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Physics(false);
            TimeManager.DoNormal();
        }
    }

    public void Physics(bool isActive) {
        if(isPhysics == isActive) return;
        isPhysics = isActive;
        _animator.enabled = !isActive;
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = !isActive;
            Reset(rigidbody);
        }

        void Reset(Rigidbody rigidbody) {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = Vector2.zero;
        }
    }
}

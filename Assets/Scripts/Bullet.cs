using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField, Range(1, 10)] private float _speedBullet = 1f;
    [SerializeField, Range(1, 300)] private float _forseImpulse = 1f;
    private Vector3 _directions;

    private void OnCollisionEnter(Collision collisionInfo) {
        if(collisionInfo.gameObject.TryGetComponent(out Rigidbody contact)){
            collisionInfo.gameObject.GetComponentInParent<IRigidObject>()?.Physics(isActive: true);
            contact.AddForce(_directions * _forseImpulse, ForceMode.Impulse);
            Time.timeScale = 1f;
        }
        Destroy(gameObject);
    }

    public void IdentifyDirectionsForce(Vector3 point){
        transform.LookAt(point);
        _directions = transform.forward;
        _rigidbody.AddForce(_directions * _speedBullet, ForceMode.VelocityChange);
    }
}

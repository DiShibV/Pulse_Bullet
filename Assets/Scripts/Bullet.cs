using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BulletImpulseData _bulletImpulseData;
    private Vector3 _directions;

    private void OnCollisionEnter(Collision collisionInfo) {
        if(collisionInfo.gameObject.TryGetComponent(out Rigidbody contact)){
            collisionInfo.gameObject.GetComponentInParent<IRigidObject>()?.Physics(isActive: true);
            contact.AddForce(_directions * _bulletImpulseData.ForseImpulse, ForceMode.Impulse);
            TimeManager.DoSlowDown();
        }
        Destroy(gameObject);
    }

    public void IdentifyDirectionsForce(Vector3 point){
        transform.LookAt(point);
        _directions = transform.forward;
        _rigidbody.AddForce(_directions * _bulletImpulseData.StartSpeedBullet, ForceMode.VelocityChange);
    }
}

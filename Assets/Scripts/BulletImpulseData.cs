using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletImpulseData", menuName = "BulletImpulseData", order = 51)]
public class BulletImpulseData : ScriptableObject
{
    [SerializeField] private float _startSpeedBullet = 1f;
    [SerializeField] private float _forseImpulse = 1f;

    public float StartSpeedBullet => _startSpeedBullet;
    public float ForseImpulse => _forseImpulse;
}

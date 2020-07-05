using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _pointBulletCreate, _cameraMain, _parentForBullets;

    private void Update() {
        if(Input.GetMouseButtonDown(0))
            CreateBullet();
    }

    private void CreateBullet(){
        if(Physics.Raycast(_cameraMain.position, _cameraMain.forward, out RaycastHit hit)) {
            var bullet = Instantiate(_bulletPrefab, _pointBulletCreate.position, Quaternion.identity, _parentForBullets);
            bullet.GetComponent<Bullet>().IdentifyDirectionsForce(hit.point);
        }
    }
}

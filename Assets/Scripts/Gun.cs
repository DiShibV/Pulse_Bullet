using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _pointBulletCreate;
    [SerializeField] private Transform _cameraMain;

    private void Update() {
        if(Input.GetMouseButtonDown(0))
            CreateBullet();
    }

    private void CreateBullet(){
        if(Physics.Raycast(_cameraMain.position, _cameraMain.forward, out RaycastHit hit)) {
            var bullet = Instantiate(_bulletPrefab, _pointBulletCreate.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().IdentifyDirectionsForce(hit.point);
        }
    }
}

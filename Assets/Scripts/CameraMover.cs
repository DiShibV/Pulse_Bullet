using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speedVertical = 1f, _speedHorizontal = 1f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update(){
        float horizontal = -Input.GetAxis("Mouse Y") * _speedVertical;
        float vertical = Input.GetAxis("Mouse X") * _speedHorizontal;
        transform.eulerAngles += new Vector3(horizontal, vertical);
    }
}

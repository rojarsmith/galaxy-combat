using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInput : MonoBehaviour
{
    public JoystickController _joystickCtr;
    CraftController _controller;
    public Transform _reCalTransform;
    bool _isShoot = false;

    void Awake()
    {
        _controller = GetComponent<CraftController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(_joystickCtr._joystickX, 0, _joystickCtr._joystickY);
        moveDir = _reCalTransform.TransformDirection(moveDir);
        _controller.Movement(moveDir);
        if (_isShoot)
        {
            _controller.ShootLaser();
        }
    }

    public void OnPressShoot(bool isPress)
    {
        _isShoot = isPress;
    }
}

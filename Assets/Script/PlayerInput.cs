using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CraftController _controller;
    public Transform _reCalTransform;

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
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDir = _reCalTransform.TransformDirection(moveDir);
        _controller.Movement(moveDir);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _controller.ShootLaser();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftController : MonoBehaviour
{
    public Transform _reCalTransform;
    Transform _transForm;
    Rigidbody _rigidBody;
    public float _moveSpeed = 15;
    public float _rotationSpeed = 10;

    void Awake()
    {
        _transForm = GetComponent<Transform>();
        _rigidBody = GetComponent<Rigidbody>();
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
        Movement(moveDir);
    }

    void Movement(Vector3 dir)
    {
        _rigidBody.velocity = dir * _moveSpeed;
        if (dir != Vector3.zero)
        {
            Quaternion rotationValue = Quaternion.LookRotation(dir);
            _transForm.rotation = Quaternion.Slerp(_transForm.rotation, rotationValue, Time.deltaTime * _rotationSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightTrigger : MonoBehaviour
{
    public Transform _target;
    Transform _transform;
    public float _targetDis;
    public float _targetAngle;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            UpdateTargetInfo();
        }
    }

    void UpdateTargetInfo()
    {
        _targetDis = Vector3.Distance(_transform.position, _target.position);
        Vector3 targetDir = _target.position - _transform.position;
        _targetAngle = Vector3.SignedAngle(_transform.forward, targetDir, Vector3.up);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _target = other.transform;
            UpdateTargetInfo();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == _target)
        {
            _target = null;
        }
    }
}

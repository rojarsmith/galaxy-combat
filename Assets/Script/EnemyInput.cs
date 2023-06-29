using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    CraftController _controller;
    SightTrigger _sightTrigger;
    public float shootDis = 50;

    private void Awake()
    {
        _controller = GetComponent<CraftController>();
        _sightTrigger = transform.Find("SightTrigger").GetComponent<SightTrigger>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float forwardValue = 0;
        float turnValue = 0;
        if (_sightTrigger._target)
        {
            turnValue = _sightTrigger._targetAngle * 0.0055f;
            if (_sightTrigger._targetDis > shootDis)
            {
                forwardValue = 1;
            }
            else
            {
                if(Mathf.Abs(_sightTrigger._targetAngle) < 45) {
                    _controller.ShootLaser();
                }
            }
        }
        _controller.Movement(forwardValue, turnValue);
    }
}

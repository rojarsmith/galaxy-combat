using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public Vector3 _offsetPos = new Vector3(11, 18, -8);
    public Transform _target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            transform.position = _target.position + _offsetPos;
        }
    }
}

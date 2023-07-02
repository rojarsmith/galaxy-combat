using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour
{
    public RectTransform _rectTrans;
    public Vector3 _startPos;
    public float _joystickX;
    public float _joystickY;
    float _clampPos;
    float _fixPos;

    // Start is called before the first frame update
    void Start()
    {
        _rectTrans = transform.Find("Controller").GetComponent<RectTransform>();
        _startPos = _rectTrans.position;

        _clampPos = GetComponent<RectTransform>().sizeDelta.x / 2;
        _fixPos = 1 / _clampPos;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData data = eventData as PointerEventData;
        _rectTrans.position = data.position;
        _rectTrans.localPosition = Vector3.ClampMagnitude(_rectTrans.localPosition, _clampPos);
        _joystickX = _rectTrans.localPosition.x * _fixPos;
        _joystickY = _rectTrans.localPosition.y * _fixPos;
    }

    public void OnEndDrag(BaseEventData eventData)
    {
        _rectTrans.position = _startPos;
        _joystickX = 0;
        _joystickY = 0;
    }
}

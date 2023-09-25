using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform handler;
    [SerializeField]
    private RectTransform joystickRectTransform;
    private Vector2 _vector;
    public Vector2 Vector => _vector;
    private Vector2 _rectCenter;
    private float _rectHeight;
    private void Start()
    {
        CalculateRectValues();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(joystickRectTransform.rect.height == 0)
        {
            Debug.LogError("Joystick height is zero");
            return;
        }
        Vector2 joystickVec = (eventData.position - (Vector2)joystickRectTransform.position - _rectCenter) / _rectHeight;
        if(joystickVec.magnitude > 1)
        {
            joystickVec.Normalize();
            handler.position = joystickRectTransform.position + (Vector3)(_rectCenter + joystickVec * _rectHeight);
        }
        else
        {
            handler.position = eventData.position;
        }
        _vector = joystickVec;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        handler.localPosition = joystickRectTransform.rect.center;
        _vector = Vector2.zero;
    }

    public void CalculateRectValues()
    {
        _rectCenter = joystickRectTransform.rect.center * UIManager.Instance.ManagerCanvas.scaleFactor;
        _rectHeight = (joystickRectTransform.rect.height / 2) * UIManager.Instance.ManagerCanvas.scaleFactor;
    }
}

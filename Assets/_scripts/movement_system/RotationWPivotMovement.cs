using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWPivotMovement : IMovement
{
    #region PROPERTIES
    private float speed;
    private Transform m_transform;

    private Vector3 _pivot;

    private Action<float> onMovementHandler = delegate { };

    #endregion

    #region CONSTRUCTOR
    public RotationWPivotMovement(Transform transform, Vector3 pivot,  float speed = 5f)
    {
        this.speed = speed;
        this.m_transform = transform;
        this._pivot = pivot;
    }
    #endregion

    #region METHODS
    public void Move()
    {
        m_transform.Rotate(_pivot, speed * Time.deltaTime);
        this.onMovementHandler(speed * Time.deltaTime);
    }

    public void SubscribeToEndCoroutine(Action handler)
    {
        Debug.Log("Shouldn't use this");
    }
    public void SubscribeOnMoveHandler(Action<float> newHandler)
    {
        onMovementHandler += newHandler;
    }
    #endregion
}

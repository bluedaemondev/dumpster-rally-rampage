using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : IMovement
{

    #region PROPERTIES
    private float speed;
    private Rigidbody m_rigidbody;

    private Vector3 direction;
    private Quaternion rotation;

    private Action<float> onMovementHandler = delegate { };

    #endregion

    #region CONSTRUCTOR
    public KeyboardMovement(Rigidbody rb, float speed = 5f)
    {
        this.speed = speed;
        this.m_rigidbody = rb;
    }
    #endregion

    #region METHODS
    public void Move()
    {
        // adaptacion del stick a coordenadas correctas
        this.direction.x = Input.GetAxis("Horizontal");
        this.direction.z = Input.GetAxis("Vertical");

        if (direction.sqrMagnitude > 0f)
        {
            m_rigidbody.transform.LookAt(m_rigidbody.transform.position + direction);
        }
        // hago el movimiento correspondiente con fixed update
        this.m_rigidbody.MovePosition(m_rigidbody.transform.position + direction * speed * Time.fixedDeltaTime);


        this.onMovementHandler(direction.magnitude);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] protected Rigidbody m_rigidbody;
    [SerializeField] protected float speed = 10;
    //protected IShooter
    public override void GrabWeaponType(PickupType type)
    {
    }

    protected override void Awake()
    {
        base.Awake();
        default_movement = new KeyboardMovement(m_rigidbody, speed);
        
        if(!m_rigidbody)
            m_rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        default_movement.Move();
    }
}

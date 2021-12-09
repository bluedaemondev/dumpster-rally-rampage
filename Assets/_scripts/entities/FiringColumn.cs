using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringColumn : Entity
{
    [SerializeField] private List<GameObject> _firepoints;
    [SerializeField] private float rot_speed = 10;
    [SerializeField] private float shootTime = 0.5f;
    [SerializeField] private float currentTime;

    Bullet b;

    public override void GrabWeaponType(PickupType type)
    {
        Debug.Log("I can\'t pickup a " + type.ToString());
    }

    protected override void Awake()
    {
        base.Awake();
        default_movement = new RotationWPivotMovement(transform, Vector3.up, rot_speed);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= shootTime)
        {
            foreach (var gp in _firepoints)
            {
                b = BulletFactory.Instance.pool.GetObject();
                b.transform.position = gp.transform.position;
                b.originalForce = gp.transform.forward;
            }

            currentTime = 0;
        }
        default_movement.Move();
    }
}

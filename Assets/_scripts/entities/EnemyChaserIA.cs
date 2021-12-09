using UnityEngine;
using UnityEngine.AI;

public class EnemyChaserIA : Entity
{
    [SerializeField] protected NavMeshAgent m_agent;

    public override void GrabWeaponType(PickupType type)
    {
        Debug.Log("I can\'t pickup a " + type.ToString());
    }

    protected override void Awake()
    {
        base.Awake();
        default_movement = new NavMeshSeekMovement(this.m_agent, FindObjectOfType<Player>().transform);
    }

    private void Update()
    {
        default_movement.Move();
    }
}

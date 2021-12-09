using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFactory : MonoBehaviour
{
    public static PickupFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static PickupFactory _instance;


    public Pickup basePickupPrefab;
    public int pickupStock = 5;

    public ObjectPool<Pickup> pool;

    void Start()
    {
        _instance = this;

        pool = new ObjectPool<Pickup>(PickupCreator, Pickup.TurnOn, Pickup.TurnOff, pickupStock);
    }

    public Pickup PickupCreator()
    {
        return Instantiate(basePickupPrefab);
    }

    public void ReturnPickup(Pickup b)
    {
        pool.ReturnObject(b);
    }
}

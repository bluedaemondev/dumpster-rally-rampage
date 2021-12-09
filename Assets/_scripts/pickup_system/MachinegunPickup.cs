using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunPickup : MonoBehaviour
{
    private Entity grabber;

    public void OnGrabPickup()
    {
        grabber.GrabWeaponType(PickupType.Machinegun);
        SoundManager.instance?.PlayAmbient("cash_pickup");
    }

    public void SetGrabber(GameObject other = null)
    {
        this.grabber = other.GetComponent<Entity>();
    }
}

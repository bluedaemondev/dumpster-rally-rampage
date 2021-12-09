using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float damage;

    [SerializeField] protected float speed;
    [SerializeField] protected float maxDistance;

    protected float _currentDistance;

    public Vector3 originalForce;

    [SerializeField] protected TrailRenderer trail;

    protected virtual void Update()
    {
        var distanceToTravel = speed * Time.deltaTime;

        transform.position += originalForce * distanceToTravel;
        _currentDistance += distanceToTravel;

        if (_currentDistance > maxDistance)
        {
            BulletFactory.Instance.ReturnBullet(this);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        var entity = other.GetComponent<IDamageable>();

        if (entity == null)
            return;

        entity.OnTakeDamage(damage);
        SoundManager.instance.PlayExtraAmbient("break_shoot");
        FindObjectOfType<CameraShake>().ShakeCameraNormal(Random.Range(5, 9), 0.22f);

        BulletFactory.Instance.ReturnBullet(this);
    }

    private void Reset()
    {
        _currentDistance = 0;

        trail.Clear();
    }


    public static void TurnOn(Bullet b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Bullet b)
    {
        //b.transform.localScale = b.originalScale;
        b.gameObject.SetActive(false);
    }
}

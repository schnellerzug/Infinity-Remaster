using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float forceMulti;
    ContactFilter2D contactFilter;
    private List<Collider2D> collidersInRange = new List<Collider2D>();

    
    [SerializeField]private float cooldown;
    private float actuelCooldown;

    private bool can = true;


    private void OnEnable()
    {
        InputManager.OnDoupleTap += CheckConditions;
    }
    private void OnDisable()
    {
        InputManager.OnDoupleTap -= CheckConditions;
    }

    private void CheckConditions(Vector3 position)
    {
        if (!can)
            return;
        transform.position = position;
        can = false;
        StartCoroutine(Timer(cooldown));
        Attract();
    }
    //private void Update()
    //{
    //    if (!can)
    //        return;

    //    if(Input.touchCount > 0)
    //    {
    //        print("Hello");
    //        var touch = Input.touches[0];
    //        if (touch.tapCount > 1)
    //        {

    //            transform.position = Camera.main.ScreenToWorldPoint(touch.position);
    //            can = false;


    //        }
    //    }


    //}

    IEnumerator Timer(float delay)
    {
        actuelCooldown = delay;
        while (actuelCooldown > 0)
        {
            actuelCooldown -= Time.deltaTime;

            yield return null;
        }
        can = true;

    }
    //private void Attract(Vector2 position)
    //{

    //    if (actuelCooldown > 0)
    //        return;
    //    actuelCooldown = cooldown;
    //    transform.position = position;
    //    Physics2D.OverlapCircle(transform.position, range, contactFilter, collidersInRange);
    //    if (collidersInRange == null)
    //        return;

    //    foreach (var collider in collidersInRange)
    //    {
    //        if (collider.attachedRigidbody != null)
    //        {
    //            var dis = collider.gameObject.transform.position - transform.position;
    //            var force = dis.normalized * (range / Mathf.Pow(dis.magnitude, 2)) * (GameManager.instance.red ? forceMulti : -forceMulti);
    //            print(force);
    //            collider.attachedRigidbody.AddForce(force, ForceMode2D.Impulse);
    //        }
    //    }
    //    StartCoroutine(Timer(cooldown));
    //}


    //private void Update()
    //{
    //    if (!can)
    //        return;

    //    if (Input.touchCount > 0)
    //    {
    //        print("Hello");
    //        var touch = Input.touches[0];
    //        if (touch.tapCount > 1)
    //        {

    //            transform.position = Camera.main.ScreenToWorldPoint(touch.position);
    //            can = false;
    //            StartCoroutine(Timer(cooldown));
    //            print("Hello");
    //            Attract();
    //        }
    //    }
    //}


    private void Attract()
    {
        Physics2D.OverlapCircle(transform.position, range, contactFilter, collidersInRange);
        if (collidersInRange == null)
            return;

        foreach (var collider in collidersInRange)
        {
            if (collider.attachedRigidbody != null)
            {
                var dis = collider.gameObject.transform.position - transform.position;
                print(dis);
                var force = dis.normalized * range / Mathf.Pow(dis.magnitude, 2) * (GameManager.instance.red ? forceMulti : -forceMulti);
                print(force);
                collider.attachedRigidbody.AddForce(force, ForceMode2D.Impulse);
            }


        }
    }
}

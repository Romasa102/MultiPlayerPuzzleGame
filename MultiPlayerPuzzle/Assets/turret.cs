using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public float Range;
    public GameObject[] Targets;
    private GameObject Target;
    bool detected = true;
    Vector2 Direction;
    public GameObject Gun;

    public GameObject bullet;
    public float fireRate;
    float NextTimeToFire = 0;

    public Transform shootPoint;
    public float Force;

    private void Update()
    {
        Targets = GameObject.FindGameObjectsWithTag("Player");

        if(Targets.Length == 2)
        {
            if (Vector2.Distance(transform.position, Targets[0].transform.position) >= Vector2.Distance(transform.position, Targets[1].transform.position))
            {
                Target = Targets[0];
            }
            else
            {
                Target = Targets[1];
            }
        }
        else
        {
            Target = Targets[0];
        }
        Vector2 targetPos = Target.transform.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        Debug.DrawRay(transform.position, Direction, Color.green);
        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                Debug.Log("WHYNOT");
                detected = true;
            }
            else
            {
                Debug.Log(rayInfo.collider.gameObject.tag);
                detected = false;
            }
        }
        if (detected)
        {
            Gun.transform.up = Direction;
            if (Time.time > NextTimeToFire)
            {
                NextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        GameObject BulletIns = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}

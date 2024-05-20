using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMove : MonoBehaviour
{
    public GameObject PointA;

    public GameObject PointB;

    public float Speed;

    Rigidbody2D rb;

    Transform CurrentPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        CurrentPoint = PointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = CurrentPoint.position -transform.position;

        if (CurrentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(Speed, 0);
        }

        else
        {
            rb.velocity = new Vector2(-Speed, 0); 
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 1.5f && CurrentPoint == PointB.transform)
        {
            CurrentPoint = PointA.transform;
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 1.5f && CurrentPoint == PointA.transform)
        {
            CurrentPoint = PointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 1.5f);

        Gizmos.DrawWireSphere(PointB.transform.position, 1.5f);
    }
}

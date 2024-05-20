using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeMove : MonoBehaviour
{
    GameObject Player;

    public float Speed;

    float distance;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);

        Vector2 Direction = Player.transform.position - transform.position;        

        if (distance < 15)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
        }
    }
}

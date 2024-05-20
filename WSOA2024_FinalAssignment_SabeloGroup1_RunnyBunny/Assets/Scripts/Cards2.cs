using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards2 : MonoBehaviour
{
    public GameObject Card1;

    public GameObject Card2;

    public GameObject Card3;

    bool FirstTime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.tag == "player")
        {          
            if (FirstTime == true)
            {
                Debug.Log("Cardsssssss");

                GameObject HealthCard = Instantiate(Resources.Load("Health"), new Vector2(-22, -2), Quaternion.identity) as GameObject;

                GameObject MentalCard = Instantiate(Resources.Load("Mental"), new Vector2(-23, -2), Quaternion.identity) as GameObject;

                GameObject HercCard = Instantiate(Resources.Load("Hercules"), new Vector2(-24, -2), Quaternion.identity) as GameObject;

                FirstTime = false;
            }          
        }

        else
        {
            Debug.Log("Already got cards!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

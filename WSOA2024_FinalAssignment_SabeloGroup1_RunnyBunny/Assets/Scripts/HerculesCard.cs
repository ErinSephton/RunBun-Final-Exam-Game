using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HerculesCard : MonoBehaviour
{
   //public GameObject DieRoll;

    bool CardCollected = false;

    bool PhysicalPhase = true;

    float Counter = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {        
            CardCollected = true;

            //GameObject.Destroy(collision.gameObject);
        }
    }

    public void OnCollected()
    {
        if (CardCollected == true)
        {
            if (PhysicalPhase == true)
            {
                Debug.Log("+2 Has Been Added To Yor Die Roll");

                /*Counter = 2;

                if (Counter > 0)
                {
                    Counter -= Time.deltaTime;

                    DieRoll.SetActive(true);
                }*/

               
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //DieRoll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Counter < 1)
        {
            DieRoll.SetActive(false);
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics.Tracing;

public class Cards : MonoBehaviour
{
    public GameObject CardSelection;

    public GameObject NoCards;

    public GameObject DieRoll;

    public TextMeshProUGUI HealthTxt;

    public TextMeshProUGUI StaminaTxt;

    bool CardCollected = false;

    bool PhysicalPhase = true;

    public float Health = 5f;

    public float Stamina = 5f;

    public float Count = 1f;

    public float Counter = 2f;

    //string[] CollectedCards;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            CardSelection.SetActive(true);
        }
    }

    public void HealthCard()
    {
        Health++;      
        
        CardSelection.SetActive(false);
    }

    public void StaminaCard()
    {
        Stamina++;

        CardSelection.SetActive(false);
    }

    public void HerculesCard()
    {     
        CardCollected = true;

        CardSelection.SetActive(false);
    }

    public void Collected()
    {
        if (CardCollected == true)
        {
            if (PhysicalPhase == true)
            {
                Counter = 2;

                if (Counter > 0)
                {
                    Counter -= Time.deltaTime;

                    DieRoll.SetActive(true);
                }

                if (Counter < 1)
                {
                    DieRoll.SetActive(false);
                }               
            }
        }

        if (CardCollected == false)
        {
            NoCards.SetActive(true);

            Count = 1;

            if (Count > 0)
            {
                Count -= Time.deltaTime;
            }

            if (Count < 1)
            {
                NoCards.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CardSelection.SetActive(false);

        NoCards.SetActive(false);

        DieRoll.SetActive(false);

        if (PhysicalPhase == true)
        {
            Debug.Log("Physical Phase");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        HealthTxt.text = "Health: " + Health;

        StaminaTxt.text = "Mental: " + Stamina;        
    }
}

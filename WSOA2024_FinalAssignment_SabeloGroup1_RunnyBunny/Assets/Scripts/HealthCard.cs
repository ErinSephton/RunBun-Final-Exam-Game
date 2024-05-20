using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthCard : MonoBehaviour
{
    public TextMeshProUGUI HealthText;

    public float Health = 2; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Health++;

            //GameObject.Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = "Health: " + Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

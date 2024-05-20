using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MentalCard : MonoBehaviour
{
    public TextMeshProUGUI MentalText;

    public float Mental = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Mental++;

            //GameObject.Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MentalText.text = "Mental: " + Mental;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

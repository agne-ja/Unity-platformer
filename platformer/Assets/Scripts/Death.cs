using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public GameObject Panel;
    private int health = 3;

    public Text healthText;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    void Update()
    {
        healthText.text = "Lives:" + health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dead"))
        {
            if (health == 1)
            {
                Panel.SetActive(true);
                Time.timeScale = 0;
                health--;
            }
            else
            {
                health--;
                gameObject.transform.position = startPosition;
            }
        }
    }
}

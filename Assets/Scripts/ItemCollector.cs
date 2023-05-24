using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text applesText;
    public int appleCounter = 1;
    [SerializeField] private int appleCountInitial = 1;

    private void Update()
    {
        if (appleCounter >= 0)
            applesText.text = "/" + appleCounter;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            appleCounter++;
            applesText.text = "/" + appleCounter;
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            appleCounter = appleCountInitial;
            applesText.text = "/" + appleCounter;
        }

    }

    public int AppleCount()
    {
        return appleCounter;
    }
    
}

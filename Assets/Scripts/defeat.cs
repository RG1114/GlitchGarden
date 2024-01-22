using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class defeat : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHealthDisplay playerhealth=FindObjectOfType<playerHealthDisplay>();
        playerhealth.reduceHealth(1);
        Destroy(other.gameObject);
    }
}

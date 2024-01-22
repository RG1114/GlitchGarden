using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject=otherCollider.gameObject;


        if(otherObject.GetComponent<gravestone>())
        {
            GetComponent<Animator>().SetTrigger("isjump");
        }

        else if(otherObject.GetComponent<Defender>())
        {
            
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}

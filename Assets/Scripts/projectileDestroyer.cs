using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class projectileDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {

        Destroy(other.gameObject);

    }
}

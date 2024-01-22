using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    [SerializeField] float projectileSpeed=5.0f;
    [SerializeField] int damage=25;
    [SerializeField] bool ammo=true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ammo==true)
        {
            transform.Translate(Vector2.up*projectileSpeed*Time.deltaTime);
        }
        else{
            transform.Translate(Vector2.right*projectileSpeed*Time.deltaTime);
        }
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {

        var health=other.GetComponent<Health>();
        var attacker =other.GetComponent<Attacker>();
        if(attacker && health)
        {
            health.HealthReduce(damage);   
            
            Destroy(gameObject);
            
        }
    }
}








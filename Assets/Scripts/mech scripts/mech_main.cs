using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mech_main : MonoBehaviour
{
    public float mech_health;


    public float damage_now;
    public float damage_offset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageStatus();
    }

    


    public void takeDamage() 
    {
        if(damage_now <= Time.time) 
        {
            mech_health--;
            Debug.Log(mech_health);
            damage_now = Time.time + damage_offset;
        }
    
    }

    void damageStatus() 
    {
        if(mech_health <= 0)
        {

            Destroy(gameObject);
        }
    }

}

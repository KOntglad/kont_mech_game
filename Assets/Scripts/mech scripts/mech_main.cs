using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mech_main : MonoBehaviour
{
    public float mech_health;
    public TMPro.TextMeshProUGUI tmp_health;

    public float damage_now;
    public float damage_offset;
    public AudioSource mech_sound;
    public AudioClip mech_warning;
    public AudioClip mech_damage;
    public float damage_volume;
    
        
    
    // Start is called before the first frame update
    void Start()
    {
        tmp_health.text = mech_health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    


    public void takeDamage() 
    {
        if(damage_now <= Time.time) 
        {
            mech_health--;
            if(mech_health <= 0) 
            {
                FindObjectOfType<game_manager>().lose();
            }
            
            AudioSource.PlayClipAtPoint(mech_damage, gameObject.transform.position, damage_volume);
            mech_sound.clip = mech_warning;
            mech_sound.Play();
            
            tmp_health.text = mech_health.ToString();
            Debug.Log(mech_health);
            damage_now = Time.time + damage_offset;
        }
    
    }

    void damageStatus() 
    {
        if(mech_health <= 0)
        {
            FindObjectOfType<game_manager>().lose();
            //Destroy(gameObject);
        
        }
    }

}

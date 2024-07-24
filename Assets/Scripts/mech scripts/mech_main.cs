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

    public StarterAssets.ThirdPersonController mech_tps_controller;

    public float hit_exit_now;
    public float hit_exit_max;


    public Transform hit_enemy_transform;
    public float hit_enemy_speed;


    public Animator mech_animator;

    public enum mech_damage_states 
    {
        normal,
        hit
    }

    public mech_damage_states mech_obj_damage_states;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mech_obj_damage_states = mech_damage_states.normal;
        tmp_health.text = mech_health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    
        switch(mech_obj_damage_states)
        {
            case mech_damage_states.normal:
                break;

            case mech_damage_states.hit:
                if(mech_tps_controller.isActiveAndEnabled == true && hit_exit_now == 0f) 
                {
                    mech_tps_controller.enabled = false;
                }
                
                hit_exit_now += Time.deltaTime;
                
                if(mech_tps_controller.isActiveAndEnabled == false) 
                {
                    //  Vector3.MoveTowards()
                
                }


                if(hit_exit_now > hit_exit_max) 
                {
                    hit_exit_now = 0f;
                    mech_tps_controller.enabled = true;
                    mech_obj_damage_states = mech_damage_states.normal;
                }


                break;

            default:
                break;
        }
    
        
    }

    


    public void takeDamage(Transform _monster_transform) 
    {
        if(damage_now <= Time.time) 
        {
            mech_health--;
            if(mech_health <= 0) 
            {
                FindObjectOfType<game_manager>().lose();
            }
            
            if(mech_obj_damage_states != mech_damage_states.hit) 
            {
                mech_obj_damage_states = mech_damage_states.hit;
                mech_animator.SetTrigger("hit");
                hit_enemy_transform = _monster_transform;
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

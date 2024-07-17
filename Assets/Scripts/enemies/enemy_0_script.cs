using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_script : MonoBehaviour
{
    public Rigidbody enemy_rb;
    public float enemy_speed;
    public float gravity;

    public float attack_radius;
    public Transform attack_position;


    //public GameObject enemy_attack_object;
    public Transform enemy_ground_detection;
    public float enemy_ground_detection_distance;
    public float attack_rotation_speed;


    public Transform player_transform;
    public Animator enemy_0_animator;
    public float enemy_attack_distance;

    public int health;
    public float damage_now;
    public float damage_offset;


    public float prepare_time_now;
    public float prepare_time_max;
    
    public float attack_time_now;
    public float attack_time_max;


    public enum enemy_states 
    {
        idle,
        follow,
        prepare,
        attack
    }

    public enemy_states enemy_object_states;

    // Start is called before the first frame update
    void Start()
    {
        enemy_object_states = enemy_states.idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemy_object_states)
        {
            case enemy_states.idle:
                enemy_object_states = enemy_states.follow;
                break;
            case enemy_states.follow:

                if (Vector3.Distance(gameObject.transform.position, player_transform.position) > enemy_attack_distance)
                {
                    transform.LookAt(new Vector3(player_transform.position.x, gameObject.transform.position.y, player_transform.position.z));
                    if (Physics.Raycast(enemy_ground_detection.position, -transform.up, 3f))
                    {
                        enemy_rb.velocity = gameObject.transform.forward * enemy_speed * Time.deltaTime;
                    }
                    else 
                    {
                        enemy_rb.velocity = gameObject.transform.up * gravity * Time.deltaTime;
                    
                    }    
                
                
                }
                else
                {
                    enemy_object_states = enemy_states.prepare;
                }
                break;
            case enemy_states.prepare:
                prepare_time_now += Time.deltaTime;
                //if (enemy_attack_object.activeSelf == false)
                //{
                //    //enemy_attack_object.SetActive(true);
                //    //enemy_attack_object.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                //}
                enemy_0_animator.SetBool("prepare", true);
                if (prepare_time_now > prepare_time_max) 
                {
                    enemy_0_animator.SetBool("prepare", false);
                    prepare_time_now = 0;
                    enemy_object_states = enemy_states.attack;
                }

                break;

            case enemy_states.attack:

                attack_time_now += Time.deltaTime;

                //enemy_attack_object.transform.Rotate(0f, attack_rotation_speed * Time.deltaTime, 0f);
                if (attack_time_now > attack_time_max)
                {
                    //enemy_attack_object.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    //enemy_attack_object.SetActive(false);
                    
                    attack_time_now = 0;
                    enemy_object_states = enemy_states.follow;
                }
                break;

        }
        
        
    }

    public void attack() 
    {
        RaycastHit[] results = Physics.SphereCastAll(attack_position.position, attack_radius, attack_position.forward, 10);
        foreach(RaycastHit result in results) 
        {
            if (result.collider.gameObject.TryGetComponent<mech_main>(out mech_main _obj_mech))
                _obj_mech.takeDamage();
        
        }
    
    }




    public void takeDamage()
    {
        if (damage_now <= Time.time)
        {
            if (health - 1 <= 0)
            {
                FindObjectOfType<spawner>().monsterEliminated();
                Destroy(gameObject);
            }
            else
            {
                health--;
                Debug.Log(health);
                damage_now = Time.time + damage_offset;
            } }

    }


}

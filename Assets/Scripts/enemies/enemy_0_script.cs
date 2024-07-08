using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_0_script : MonoBehaviour
{
    public CharacterController enemy_cc;
    public float enemy_speed;
    
    public Transform player_transform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(player_transform.position.x,gameObject.transform.position.y,player_transform.position.z));
        enemy_cc.Move(gameObject.transform.forward * enemy_speed * Time.deltaTime);

    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("hey");
            if(collision.gameObject.TryGetComponent<mech_main>(out mech_main _player))
            {
                _player.takeDamage(gameObject.transform);
            }
        }
    }

   
}

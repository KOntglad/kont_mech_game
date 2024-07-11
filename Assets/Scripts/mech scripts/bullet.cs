using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 11)
        {
            if(collision.gameObject.TryGetComponent<enemy_0_script>(out enemy_0_script _enemy))
            {
                _enemy.takeDamage();
            }
        }
    }
}

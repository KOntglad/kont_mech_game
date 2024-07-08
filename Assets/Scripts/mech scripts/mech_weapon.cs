using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class mech_weapon : MonoBehaviour
{
    // Start is called before the first frame update

    private Player_new player_mouse_input;
    

    void Awake()
    {
        player_mouse_input = new Player_new();
        
    }

    private void OnEnable()
    {
        player_mouse_input.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

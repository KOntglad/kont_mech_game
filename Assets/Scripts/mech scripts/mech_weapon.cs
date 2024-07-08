using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class mech_weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI tmp_x;
    public TMPro.TextMeshProUGUI tmp_y;
    
    private Player_new player_mouse_input;
    public  StarterAssets.StarterAssetsInputs player_sai;
    
    float mouse_input_x;
    float mouse_input_y;

    public GameObject mech_cannon;

    void Awake()
    {
        player_mouse_input = new Player_new();
        player_sai = GetComponent<StarterAssets.StarterAssetsInputs>();
        
    }

    private void OnEnable()
    {
        player_mouse_input.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        handleInputs();  
    }

    void handleInputs() 
    {
        mouse_input_x = player_mouse_input.player.player_mouse_x.ReadValue<float>();
        mouse_input_y = player_mouse_input.player.player_mouse_y.ReadValue<float>();
        //tmp_x.text = mouse_input_x.ToString();
        //tmp_y.text = mouse_input_y.ToString();
        tmp_x.text = player_sai.look.x.ToString();
        tmp_y.text = player_sai.look.y.ToString();
    }


    void rotate_cannon() 
    {
    //    Quaternion mech_new_rotation;
    //    mech_new_rotation = 
    //        //(player_sai.look.x,0f,player_sai.look.y);
    }
}

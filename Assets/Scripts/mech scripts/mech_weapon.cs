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
    
    float _mouse_input_x;
    float _mouse_input_y;

    float _x_axis;
    float _x_axis_angle;
    float _y_axis;
    public float sensitivity;

    public GameObject rotation_object;
    public GameObject mech_cannon;
    public Quaternion late_mech_rotation;

    public float speed = 0.01f;
    public float timeCount = 0.0f;


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
        //go_cannon();
        //rotate_cannon();
        //rotate_cannon_new();
        rotate_cannon_lerp();
    }

    void handleInputs() 
    {
        _mouse_input_x = player_mouse_input.player.player_mouse_x.ReadValue<float>();
        _mouse_input_y = player_mouse_input.player.player_mouse_y.ReadValue<float>();
        //tmp_x.text = mouse_input_x.ToString();
        //tmp_y.text = mouse_input_y.ToString();
        tmp_x.text = player_sai.look.x.ToString();
        tmp_y.text = player_sai.look.y.ToString();
        _x_axis += player_sai.look.x * Time.deltaTime * sensitivity;
        _y_axis += player_sai.look.y * Time.deltaTime * sensitivity;

    }

    void go_cannon()
    {
        mech_cannon.transform.position = gameObject.transform.position * Time.deltaTime;
    }
    void rotate_cannon() 
    {
        _x_axis_angle -= _y_axis;
        _x_axis_angle = Mathf.Clamp(_x_axis_angle, -90, 90);
        mech_cannon.transform.localRotation = Quaternion.Euler(_x_axis,0f,0f);
        mech_cannon.transform.Rotate(Vector3.up * _x_axis);
    }


    void rotate_cannon_new() 
    {
        mech_cannon.transform.rotation = rotation_object.transform.rotation;
    }
    
    void rotate_cannon_lerp() 
    {
        mech_cannon.transform.rotation = Quaternion.Lerp(mech_cannon.transform.rotation, rotation_object.transform.rotation, Time.deltaTime * speed);
        
    }
}

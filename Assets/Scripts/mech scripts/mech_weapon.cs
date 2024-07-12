using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class mech_weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI tmp_x;
    public TMPro.TextMeshProUGUI tmp_y;
    public TMPro.TextMeshProUGUI tmp_move_x;
    public TMPro.TextMeshProUGUI tmp_move_y;
    public TMPro.TextMeshProUGUI tmp_bullet_status;
    
    private Player_new player_mouse_input;
    public  StarterAssets.StarterAssetsInputs player_sai;
    
    float _mouse_input_x;
    float _mouse_input_y;

    float _x_axis;
    float _x_axis_angle;
    float _y_axis;
    public float sensitivity;

    public GameObject rotation_object;
    public float offset_x;
    public float offset_y;
    public float offset_z;

    
    public GameObject mech_cannon;
    public Transform bullet_fire_transform;
    public Vector3 mech_cannon_offset;

    public GameObject bullet;
    public float bullet_speed;
    public float bullet_destroy_sec;

    public Quaternion late_mech_rotation;


    public float speed = 0.01f;
    public float timeCount = 0.0f;

    float fire_time_now;
    public float fire_time_offset;


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
        bulletStatus();


        if (player_mouse_input.player.fire.triggered && fire_time_now < Time.time) 
        {
            fire_time_now = Time.time + fire_time_offset;
            fire();
        }
        
        handleInputs();
        go_cannon();
        rotate_cannon_lerp();
        

        
        //rotate_cannon();
        //rotate_cannon_new();
    }

    void handleInputs() 
    {
        _mouse_input_x = player_mouse_input.player.player_mouse_x.ReadValue<float>() * 3;
        _mouse_input_y = player_mouse_input.player.player_mouse_y.ReadValue<float>() * 3;
        
        
        //tmp_x.text = mouse_input_x.ToString();
        //tmp_y.text = mouse_input_y.ToString();
        tmp_x.text = player_sai.look.x.ToString();
        tmp_y.text = player_sai.look.y.ToString();

        tmp_move_x.text = player_sai.move.x.ToString("0");
        tmp_move_y.text = player_sai.move.y.ToString("0");
        
        
        _x_axis += player_sai.look.x * Time.deltaTime * sensitivity;
        _y_axis += player_sai.look.y * Time.deltaTime * sensitivity;

    }

    void go_cannon()
    {
        mech_cannon.transform.position = gameObject.transform.position + mech_cannon_offset;
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

        Quaternion temp = Quaternion.Euler(-rotation_object.transform.rotation.eulerAngles.x + offset_x, rotation_object.transform.rotation.eulerAngles.y + offset_y, rotation_object.transform.rotation.eulerAngles.z + offset_z);
        mech_cannon.transform.rotation = Quaternion.Lerp(mech_cannon.transform.rotation, temp, Time.deltaTime * speed);
        
    }

    void bulletStatus() 
    {
        if(fire_time_now > Time.time) 
        {
            tmp_bullet_status.text = "WAIT";
        }
        else
        {
            tmp_bullet_status.text = "FIRE";
        }
    }


    void fire()
    {

        GameObject bullet_clone = Instantiate(bullet, bullet_fire_transform.position, bullet_fire_transform.rotation);
        bullet_clone.TryGetComponent<Rigidbody>(out Rigidbody bullet_rb);
        if (bullet_rb != null)
        {
            bullet_rb.velocity = -bullet_clone.transform.forward * bullet_speed * Time.deltaTime;
            Destroy(bullet_clone, bullet_destroy_sec);
        }
    }
    
}

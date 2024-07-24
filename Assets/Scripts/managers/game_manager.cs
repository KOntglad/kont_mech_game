using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public spawner game_spawner;
    public GameObject panel_victory;
    public GameObject panel_defeat;
    public GameObject player_hud;

    public TMPro.TextMeshProUGUI tmp_time;
    
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        tmp_time.text = time.ToString("F1");
        
        if(time <= 0f) 
        {
            lose();
        }        
        
        
        victoryStatus();

    }


    void victoryStatus() 
    {
        if (game_spawner.eliminated_monsters >= game_spawner.max_spawned_monsters) 
        {
            player_hud.SetActive(false);
            panel_victory.SetActive(true);
            Time.timeScale = 0f;
        }
    
    }


    public void lose() 
    {
        Time.timeScale = 0f;
        player_hud.SetActive(false);
        panel_defeat.SetActive(true);        
        Debug.Log("lose");
    }

    void openMenu()
    {
        if(panel_victory.activeSelf == false)
        panel_victory.SetActive(true);
        
    } 
    
    void closeMenu()
    {
        if(panel_victory.activeSelf == true)
        panel_victory.SetActive(false);
    
    }


}

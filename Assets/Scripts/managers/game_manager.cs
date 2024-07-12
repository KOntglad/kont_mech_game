using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public spawner game_spawner;
    public GameObject panel_paused;
    public GameObject player_hud;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        victoryStatus();
    }


    void victoryStatus() 
    {
        if (game_spawner.eliminated_monsters >= game_spawner.max_spawned_monsters) 
        {
            player_hud.SetActive(false);
            panel_paused.SetActive(true);
            Time.timeScale = 0f;
        }
    
    }


    void lose() 
    {
        Debug.Log("lose");
    }

    void openMenu()
    {
        if(panel_paused.activeSelf == false)
        panel_paused.SetActive(true);
        
    } 
    
    void closeMenu()
    {
        if(panel_paused.activeSelf == true)
        panel_paused.SetActive(false);
    
    }


}

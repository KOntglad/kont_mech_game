using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
    public spawner game_spawner;
    public GameObject panel_paused;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void victoryStatus() 
    {
        if (game_spawner.eliminated_monsters >= game_spawner.max_spawned_monsters) 
        {
            Debug.Log("victory");       
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

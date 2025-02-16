using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] spawn_points;
    public GameObject[] spawn_objects;

    public float spawn_time;
    
    public float spawn_time_offset;
    public int spawn_count_behaviour;
    
    public int eliminated_monsters;
    
    public int max_spawned_monsters;
    public int now_spawned_monsters;

    int temp = 0;

    public enum spawner_states 
    {
        single,
        multiple
    
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn_time += Time.deltaTime;
        if(spawn_time > spawn_time_offset && now_spawned_monsters < max_spawned_monsters) 
        {
            int rand = (int)Random.Range(0, spawn_points.Length);
            if (temp != rand)
            {
                spawnObject(rand);
                now_spawned_monsters++;
                spawn_time = 0f;
            }
            else
                return;
        }
    }

    void spawnObject(int point) 
    {
        Instantiate(spawn_objects[(int)Random.Range(0,2.1f)],spawn_points[point].position, spawn_points[point].rotation);
    }

    public void monsterEliminated()
    {
        eliminated_monsters++;
    }
}

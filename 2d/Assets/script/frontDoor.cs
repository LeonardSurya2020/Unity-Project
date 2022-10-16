using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontDoor : switch_scene
{
    public Transform player;
    public float posx;
    public float posy;
    public string previous;

    public override void Start()
    {
        base.Start();

        if(prevScene == previous)
        {
            player.position = new Vector2(posx, posy);
        }
    }
}

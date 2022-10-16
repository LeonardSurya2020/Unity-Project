using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opendoor : MonoBehaviour
{
    private bool player_detected;
    public Transform doorpos;
    public float width;
    public float height;

    public LayerMask what_is_player;
    switch_scene switchscene;
    [SerializeField]
    private string sceneName;

    private void Start()
    {
        switchscene = FindObjectOfType<switch_scene>();
    }

    // Update is called once per frame
    void Update()
    {
        player_detected = Physics2D.OverlapBox(doorpos.position, new Vector2(width, height), 0, what_is_player);

        if(player_detected == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                switchscene.switchScene(sceneName);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorpos.position, new Vector3(width, height, 1));
    }
}

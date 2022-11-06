using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameLogic gl;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gl.activePhase == Phase.Gameplay)
        {
            this.transform.position = player.position + new Vector3(0.0f, 10.0f, -3.0f);
        }
    }
}

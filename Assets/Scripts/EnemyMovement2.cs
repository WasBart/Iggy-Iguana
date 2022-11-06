using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{   
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        cc.Move(this.transform.forward * Time.deltaTime * 5);
    }

    public void ChangeDirection()
    {
        this.transform.Rotate(new Vector3(0,180,0));
    }
}

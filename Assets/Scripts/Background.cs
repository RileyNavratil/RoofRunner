using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Background : MonoBehaviour
{

public float imageTempo;

public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        imageTempo = imageTempo/60f;

    }

    // Update is called once per frame
    void Update()
    {
        
	if(!hasStarted){
	 if(Input.anyKeyDown){
	hasStarted = true;
	} 

}
else{
transform.position -= new Vector3(imageTempo * Time.deltaTime, 0.0f, 0.0f) ;
}

    }
}

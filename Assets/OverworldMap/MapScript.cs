using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField] Transform[] levels;
    Transform cam;
    int currentIndex = 0;
    [SerializeField] float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform.parent;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cam.position = Vector2.Lerp (cam.position, levels [currentIndex].position, .5f);
    }

    public void ClickRight(){
        Move (1);
    }

    public void ClickLeft(){
        Move (-1);
    }

    void Move(int dir){
        currentIndex += dir;
        currentIndex = (currentIndex<0) ? levels.Length - 1 : currentIndex;
        currentIndex = (currentIndex >= levels.Length) ? 0 : currentIndex;
    }

}

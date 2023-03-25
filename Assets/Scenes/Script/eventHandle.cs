using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class eventHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public bool IsLeft;
    

    private void Awake()
    {
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(!IsLeft)
        {
            PlayerMovement.instance.dirX = 1;
        }
        else
        {
            PlayerMovement.instance.dirX = -1;
        }
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerMovement.instance.dirX = 0;
    }
    
}

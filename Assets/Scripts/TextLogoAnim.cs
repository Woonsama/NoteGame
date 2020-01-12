using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogoAnim : MonoBehaviour
{
    public Text text;
    public float speed;

    [Header("Lerp Depart Position")]
    [SerializeField] float departXPos;
    [SerializeField] float departYPos;
    [SerializeField] float departZPos;

    [Header("Lerp Smooth")]
    public float smooth;


    void Start()
    {
        
    }

    void Update()
    {
        TextAnimation();
    }

    public void TextAnimation()
    {
        //Anim Play
        transform.position += Vector3.Lerp(transform.position,new Vector3(departXPos,departYPos,departZPos),smooth * Time.deltaTime);
    }
}

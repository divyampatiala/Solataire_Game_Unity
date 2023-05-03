using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressableButton : MonoBehaviour
{
    private GameObject game_controller;
    public bool allowPressing;
    private void Start()
    {
        game_controller = GameObject.FindGameObjectWithTag("CardGameController");
        allowPressing = true;
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("Pressed");
    //    game_controller.GetComponent<GameController>().CallOpenCards();
    //}
    private void OnMouseDown()
    {
        if (allowPressing == true)
        {
            game_controller.GetComponent<Rtest>().CallOpenCards();
        }
        // game_controller.GetComponent<GameController>().iteration++;
    }
}

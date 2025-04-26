/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Search;
using UnityEngine.EventSystems;

public class Button_UI :  MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {
    public enum ButtonType {Button, Toggle}
    [Header("Type of Buton")]
    public ButtonType btnType;

    [Header("Button Hover")]
    public Image hoverBehaviour_Image;
    public Color hoverBehaviour_Color_Enter, hoverBehaviour_Color_Exit;
    [Header("Sprite Toggle")]
    [HideInInspector]
    public bool toggle = true;
    public Sprite yesBehaviour_Toggle;
    public Sprite noBehaviour_Toggle;

    public Action ClickFunc;
    private Action hoverBehaviourFunc_Enter, hoverBehaviourFunc_Exit;
    private Action yesBehaviourToggle_Onclick, noBehaviourToggle_Onclick;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(btnType == ButtonType.Toggle) SetToggle();

        ClickFunc.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverBehaviourFunc_Enter != null) hoverBehaviourFunc_Enter();
    }
    private void SetToggle()
    {
        if (toggle == true && noBehaviourToggle_Onclick != null && yesBehaviourToggle_Onclick != null)
            noBehaviourToggle_Onclick();
        else if (noBehaviourToggle_Onclick != null && yesBehaviourToggle_Onclick != null)
            yesBehaviourToggle_Onclick();
    }
    public bool GetToggle() => toggle;
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverBehaviourFunc_Exit != null) hoverBehaviourFunc_Exit();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
    public void SetHoverBehaviourType() 
    {
        hoverBehaviourFunc_Enter = delegate () { hoverBehaviour_Image.color = hoverBehaviour_Color_Enter; };
        hoverBehaviourFunc_Exit = delegate () { hoverBehaviour_Image.color = hoverBehaviour_Color_Exit; };
    }
    public void SetToggleBehaviour()
    {
        yesBehaviourToggle_Onclick = delegate () { hoverBehaviour_Image.sprite = yesBehaviour_Toggle; toggle = true; }; 
        noBehaviourToggle_Onclick = delegate () { hoverBehaviour_Image.sprite = noBehaviour_Toggle; toggle = false; };
    }
}

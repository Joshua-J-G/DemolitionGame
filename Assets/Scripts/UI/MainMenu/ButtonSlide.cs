using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image StartingText;
    public Image OverlayText;

    Vector3 origionalPosition;

    bool isPlayerHoveringOverbutton = false;

    // Start is called before the first frame update
    void Start()
    {
        origionalPosition = OverlayText.transform.position; 

    }

    public void PlayerHoverOverButton()
    {
        isPlayerHoveringOverbutton = true;
    }

    public void PlayerStopedHoverOverButton()
    {
        isPlayerHoveringOverbutton = false;
    }


    float timeHasBeenHoveredOver;

    // Update is called once per frame
    void Update()
    {
        if(isPlayerHoveringOverbutton)
        {
            OverlayText.transform.position = Vector3.Lerp(OverlayText.transform.position, StartingText.transform.position, timeHasBeenHoveredOver);
            timeHasBeenHoveredOver += Time.deltaTime;
        }else
        {
            OverlayText.transform.position = Vector3.Lerp(OverlayText.transform.position, origionalPosition, 1f - timeHasBeenHoveredOver);
            timeHasBeenHoveredOver -= Time.deltaTime;
        }

        timeHasBeenHoveredOver = Mathf.Clamp01(timeHasBeenHoveredOver);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        PlayerHoverOverButton();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerStopedHoverOverButton();
    }
}

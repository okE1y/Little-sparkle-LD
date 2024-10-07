using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuMenager : MonoBehaviour
{
    private List<IUIButton> uIButtons = new List<IUIButton>();
    [SerializeField] private GameObject[] buttonsObjects = new GameObject[2];

    private int SelectedButton = 0;

    public bool ActiveMenu = true;

    private void Start()
    {
        IUIButton uIButton;
        for (int i = 0; i < buttonsObjects.Length; i++)
        {
            if (buttonsObjects[i].TryGetComponent<IUIButton>(out uIButton))
            {
                uIButtons.Add(uIButton);
            }
        }

        uIButtons[SelectedButton].SetSelected(true);
    }

    private int RepeatButtonCounter(int counter, int MaxValue)
    {
        if (counter > MaxValue) return 0;
        else if (counter < 0) return MaxValue;

        return counter;
    }

    public void GetVerticalAxis(InputAction.CallbackContext context)
    {
        if (ActiveMenu && context.started)
        {
            float VerticalAxis = context.ReadValue<float>();
            if (VerticalAxis != 0)
            {
                VerticalAxis = Mathf.Sign(VerticalAxis);

                uIButtons[SelectedButton].SetSelected(false);

                SelectedButton += Mathf.RoundToInt(VerticalAxis);

                SelectedButton = RepeatButtonCounter(SelectedButton, uIButtons.Count - 1);

                uIButtons[SelectedButton].SetSelected(true);
            }
        }
    }

    public void ButtonPushed(InputAction.CallbackContext context)
    {
        if (ActiveMenu && context.started)
        {
            uIButtons[SelectedButton].InvokeAction();
        }
    }
}

public interface IUIButton
{
    public void InvokeAction();

    public void SetSelected(bool selected);
}

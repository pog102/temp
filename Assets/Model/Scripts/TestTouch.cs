using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Needed to detect UI touches
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestTouch : MonoBehaviour
{
    private Animator animate;

    public GameObject Vamp; // drag it in from the Hierarchy
    private TouchControls touchControls;
    private bool isAngel = false; // track current state
    private Camera mainCamera;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        animate = Vamp.GetComponent<Animator>();

        ToggleAngel(); // Start as angel
        // touchControls.Touch.TouchPress.started += ctx => ToggleRun();
        // touchControls.Touch.TouchPress.started += ctx => HandleTouch();
        // touchControls.Touch.TouchPress.started += ctx => OnTouch();
        // if (angelButton != null)
        //     angelButton.onClick.AddListener(ToggleAngel);
        // ToggleAngel(); // Start as angel
    }

    private void ToggleAngel()
    {
        isAngel = !isAngel; // flip the state

        // Trigger a jump animation
        // animate.SetBool("isAngel", isAngel);
        print(animate);
        animate.SetBool("isAngel", true);
    }
}

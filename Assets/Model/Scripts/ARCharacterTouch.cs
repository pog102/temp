using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.EventSystems; // Needed to detect UI touches
// using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ARCharacterTouch : MonoBehaviour
{
    private Animator animate;

    private TouchControls touchControls;
    private bool isRunning = false; // track current state
    private bool isAngel = false; // track current state

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
        animate = GetComponent<Animator>();

        // touchControls.Touch.Button.performed += ctx => ToggleAngel();
        // touchControls.Touch.TouchPress.started += ctx => ToggleRun();
    }

    private void ToggleAngel()
    {
        isAngel = !isAngel; // flip the state

        animate.SetBool("isAngel", isAngel);
    }

    public void ToggleRun()
    {
        isRunning = !isRunning; // flip the state

        animate.SetBool("isRun", isRunning);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Vamp")
                {
                    ToggleAngel();

                    // hit.transform.GetComponent<ARCharacterTouch>().ToggleAngel();
                }
            }
        }
    }
}

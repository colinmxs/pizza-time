using UnityEngine;
using UnityEngine.UI;

public class SubmitOnEnter : MonoBehaviour
{
    InputField input;
    bool allowEnter;

    void Awake()
    {
        input = GetComponent<InputField>();
    }

    void Update()
    {

        if (allowEnter && (input.text.Length > 0) && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            //OnSubmit();
            allowEnter = false;
        }
        else
            allowEnter = input.isFocused;
    }
}

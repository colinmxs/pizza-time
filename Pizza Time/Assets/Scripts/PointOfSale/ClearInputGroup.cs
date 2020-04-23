using UnityEngine;
using UnityEngine.UI;

public class ClearInputGroup : MonoBehaviour
{
    InputField[] Inputs;

    private void Start()
    {
        Inputs = GetComponentsInChildren<InputField>();
    }

    public void ClearInputs()
    {
        foreach (var input in Inputs)
        {
            input.text = string.Empty;
        }
    }
}

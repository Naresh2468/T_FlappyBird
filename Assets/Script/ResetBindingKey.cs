using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ResetBindingKey : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActions;
    // Start is called before the first frame update
    public void ResetAllBindingKeys()
    {
        foreach (InputActionMap map in  _inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides();
        }
        PlayerPrefs.DeleteKey("rebinds");
    }
}

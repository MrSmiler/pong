using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ExitClicked);
    }

    void ExitClicked()
    {
        Application.Quit();
        #if DEBUG
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

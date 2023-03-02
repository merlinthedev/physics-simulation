using System;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private InputField _inputField;

    public event Action<int> OnChatTextEntered = delegate { };

    private void Start() {
        _inputField.onEndEdit.AddListener(
            (value) => {
                if(value == "") return;
                if(Input.GetKeyDown(KeyCode.Return)) OnChatTextEntered(int.Parse(value));
            }
        );

        OnChatTextEntered += onChatTextEntered;

        Debug.Log("InputHandler started");
    }


    private void onChatTextEntered (int value) {
        Debug.Log(value);
        GameManager.getInstance().setAmountOfObjects(value);
    }

}


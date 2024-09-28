using System;
using TMPro;
using UnityEngine;

public class NameChooserUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _errorTextObject;

    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private GeneralEvent _playerAddEvent, _switchSceneEvent;

    public void StoreName()
    {
        _playerAddEvent.Raise(new PlayerAddEventArgs(new PlayerData { Username = _nameText.text}));
    }

    public void OnPlayerAdded(EventArgs eventArgs)
    {
        PlayerAddedEventArgs playerAddEventArgs = (PlayerAddedEventArgs)eventArgs;

        if (playerAddEventArgs.Success)
        {
            _errorTextObject.SetActive(false);
            _switchSceneEvent.Raise();
        }
        else
        {
            _errorTextObject.SetActive(true);
        }
    }
}
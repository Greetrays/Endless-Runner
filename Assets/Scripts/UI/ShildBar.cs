using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent (typeof(Image))] 

public class ShildBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UnityEvent _removeShild;

    private Coroutine _changeBar;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
        _changeBar = null;
    }

    private void OnEnable()
    {
        _player.UsedShild += OnStartChangeBar;
    }

    private void OnDisable()
    {
        _player.UsedShild -= OnStartChangeBar;
    }

    private void OnStartChangeBar(float fullTime)
    {
        if (_changeBar == null)
        {
            _changeBar = StartCoroutine(ChangeBar(fullTime));
        }
        else
        {
            _image.fillAmount = 1;
            StopCoroutine(_changeBar);
            _changeBar = StartCoroutine(ChangeBar(fullTime));
        }
    }

    private IEnumerator ChangeBar(float fullTime)
    {
        float elepsedTime = 0;
        int a = 1;
        int b = 0;

        while (elepsedTime < fullTime)
        {
            _image.fillAmount = Mathf.Lerp(a, b, elepsedTime / fullTime);
            elepsedTime += Time.deltaTime;
            yield return null;
        }

        _changeBar = null;
        Destroy();
    }

    private void Destroy()
    {
        _image.fillAmount = 0;
        _removeShild?.Invoke();
        _player.SwitchProtected(false);
    }
}

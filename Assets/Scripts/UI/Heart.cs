using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class Heart : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        _image.fillAmount = 1;
    }

    public void ToEmpty()
    {
        Destroy(gameObject);
    }

    /*public void ToFill()
    {
        StartCoroutine(Filling(0, 1, Filling));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, Destroy));
    }

    private IEnumerator Filling (float startValue, float endValue, UnityAction<float> lerpingEnd)
    {
        float elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            _image.fillAmount = Mathf.Lerp(startValue, endValue, elapsedTime / _duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Filling(float value)
    {
        _image.fillAmount = value;
    }*/
}

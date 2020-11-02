using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float MaxAlpha;
    public GameObject Player;

    private SpriteRenderer _sprite;
    private float _tempColor;
    private bool _fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _sprite.color = new Color(1f, 1f, 1f, MaxAlpha);
    }

    // Update is called once per frame
    void Update()
    {
        _sprite.color = new Color(1f, 1f, 1f, _tempColor);

        if (_fadeIn == true)
        {
            if (_tempColor <= MaxAlpha)
            {
                _tempColor += 0.005f;
                Player.SetActive(false);
            }
        }
        else
        {
            if (_tempColor >= 0f)
            {
                _tempColor -= 0.005f;

            }
        }
    }
    public void CloudFadeIn()
    {
        _fadeIn = true;
    }
}

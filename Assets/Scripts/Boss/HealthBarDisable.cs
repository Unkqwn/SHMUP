using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarDisable : MonoBehaviour
{
    [SerializeField] GameObject _Bar;
    ScrollingPlayer _scrollingPlayer;
    void Start()
    {
        _scrollingPlayer = GetComponent<ScrollingPlayer>();
    }

    void Update()
    {
        if (_scrollingPlayer == true )
        {
            _Bar.SetActive(false);
        }
        if (_scrollingPlayer.canMove == false)
        {
            _Bar.SetActive(true);
        }
    }
    #region
    //Code By Roman Agterberg
    #endregion
}

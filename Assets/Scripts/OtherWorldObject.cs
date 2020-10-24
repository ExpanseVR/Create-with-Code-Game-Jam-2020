using CreateWithCodeGameJam2020.FlutePlayer;
using CreateWithCodeGameJam2020.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorldObject : MonoBehaviour
{
    [SerializeField]
    private GameManager.Worlds _worldBelongsTo;

    [SerializeField]
    private GameObject _chest;

    private bool _isVisible = false;

    private void OnEnable()
    {
        Flute.onChangeWorld += ChangeWorld;
    }

    private void ChangeWorld (GameManager.Worlds currentWorld)
    {
        if (_worldBelongsTo == currentWorld)
        {
            _chest.SetActive(true);
            _isVisible = true;
        }
        else
        {
            _chest.SetActive(false);
            _isVisible = false;
        }
    }

    private void OnDisable()
    {
        Flute.onChangeWorld -= ChangeWorld;
    }
}

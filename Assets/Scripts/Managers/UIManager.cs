using CreateWithCodeGameJam2020.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image _flute;
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        Item.onGetItem += FluteObtained;
    }

    private void FluteObtained (Item.ItemType itemType)
    {
        if (itemType == Item.ItemType.Flute)
            _flute.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        Item.onGetItem += FluteObtained;
    }
}

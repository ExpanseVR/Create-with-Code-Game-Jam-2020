using CreateWithCodeGameJam2020.Manager;
using CreateWithCodeGameJam2020.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _startScreen;

    [SerializeField]
    private Image _flute, _key;
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

    public void StartGame()
    {
        //make sure cursor is not visible in game
        Cursor.lockState = CursorLockMode.Locked;
        _startScreen.SetActive(false);
        GameManager.Instance.PlayGameMusic();
    }
}

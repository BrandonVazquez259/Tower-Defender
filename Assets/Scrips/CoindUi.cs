using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CoindUi : MonoBehaviour
{
    [SerializeField]
    private Text _coinsText;
    [SerializeField]
    private UnityEvent _onCoinsUpdated;
    public void UpdateCoins(int coins)
    {
        _coinsText.text = "X" + coins.ToString();
        _onCoinsUpdated?.Invoke();
    }
}

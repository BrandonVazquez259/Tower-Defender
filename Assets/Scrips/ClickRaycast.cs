using UnityEngine;
using UnityEngine.Events;

public class ClickRaycast : MonoBehaviour
{
    [SerializeField]
    private LayerMask _raycastLayerMask;
    [SerializeField]
    private string _cointTagName = "Coin";
    [SerializeField]
    private float _rayDistance = 100f;
    [SerializeField]
    private UnityEvent <Transform>_onCoinCollected;
    private bool _isActive = true;
    public bool IsActive { set => _isActive = value; }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _rayDistance, _raycastLayerMask))
            {
                Coin coin = hit.collider.GetComponent<Coin>();
                if (coin != null)
                {
                    CoinCollected(coin);
                }
            }
        }

    }
    private void CoinCollected(Coin coin)
    {
        coin.Collect();
        _onCoinCollected?.Invoke(coin.transform);
     }

}

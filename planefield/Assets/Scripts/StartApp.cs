using System.Collections.Generic;
using Ship.Enemy;
using UnityEngine;
using Zenject;

public class StartApp : MonoBehaviour
{
    [Inject] private EnemyShip.Factory _enemyShipFactory;
    
    [SerializeField] private Transform[] _markers;

    private List<EnemyShip> _enemyShips = new();

    private void Start()
    {
        for (int i = 0; i < _markers.Length; i++)
        {
           var enemyShip = _enemyShipFactory.Create (new Vector2(_markers[i].position.x,_markers[i].position.y));
           _enemyShips.Add(enemyShip);
        }
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "BrickFactoryConfig", menuName = "Scriptable Object/Brick FactoryConfig")]
public class BrickFactoryConfig : ScriptableObject
{
    [SerializeField] private GameObject _standardBrickPrefab;
    [SerializeField] private GameObject _unbreakableBrickPrefab;
    [SerializeField] private GameObject _bonusBrickPrefab;

    public GameObject StandardBrickPrefab => _standardBrickPrefab;
    public GameObject UnbreakableBrickPrefab => _unbreakableBrickPrefab;
    public GameObject BonusBrickPrefab => _bonusBrickPrefab;
}
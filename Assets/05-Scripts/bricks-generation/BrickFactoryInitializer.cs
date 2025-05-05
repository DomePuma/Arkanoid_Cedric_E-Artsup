using UnityEngine;

public class BrickFactoryInitializer : MonoBehaviour
{
    [SerializeField] private BrickFactoryConfig _config;

    private void Awake()
    {
        BrickFactory.Initialize(_config, transform);
    }
}
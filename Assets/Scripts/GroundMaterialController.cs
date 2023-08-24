using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMaterialController : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private List<Parallax> _planes;

    public void SetRandomMaterial()
    {
        int materialIndex = Random.Range(0, _materials.Count);

        for (int i = 0; i < _planes.Count; i++)
        {
            _planes[i].SetMaterial(_materials[materialIndex]);
        }
    }

    private void Awake()
    {
        SetRandomMaterial();
    }
}

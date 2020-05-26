using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Manager", menuName = "ScriptableObjects/Managers")]
public class ParticalManager : ScriptableObject
{
    public void Effect(GameObject partical, float lifeTime, Transform transform)
    {
        GameObject tmpPartical = Instantiate(partical, transform.position, Quaternion.identity);
        DestroyPartical(tmpPartical, lifeTime);
    }
    private void DestroyPartical(GameObject partical, float lifeTime) { Destroy(partical, lifeTime); }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private BombData initialbombData;
    [SerializeField]
    private new Collider2D collider;

    private BombData bombData;
    private WaitForSeconds countDown;
    private MapDestroyer mapDestroyer;
    private Collider2D otherBomb;
    private void Awake()
    {
        bombData = new BombData();

        bombData.countDown = initialbombData.countDown;
        bombData.range = initialbombData.range;

        bombData.bombCount = initialbombData.bombCount;
        countDown = new WaitForSeconds(bombData.countDown);

        StartCoroutine(Explosion());
    }
    private void Start()
    {
        mapDestroyer = MapDestroyer.Instance;
    }
    IEnumerator Explosion()
    {
        initialbombData.bombCount--;

        yield return countDown;

        initialbombData.bombCount++;
        Destroy(gameObject);
        mapDestroyer.Explode(transform.position, bombData.range);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagContainer.PLAYER_TAG))
        {
            collider.gameObject.SetActive(true);
        }
    }
    public void ApplyDamage()
    {
        initialbombData.bombCount++;
        mapDestroyer.Explode(transform.position, bombData.range);
        Destroy(gameObject);
    }
}

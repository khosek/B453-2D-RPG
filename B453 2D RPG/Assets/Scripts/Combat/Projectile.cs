using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public CombatCharacter target;

    [SerializeField] protected int damage;

    public void Initialize(CombatCharacter target)
    {
        this.target = target;
        StartCoroutine(Fly());
    }

    protected virtual IEnumerator Fly()
    {
        while (transform.position != target.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 50 * Time.deltaTime);
            yield return null;
        }

        target.TakeDamage(damage);

        TurnManager.instance.EndTurn();

        Destroy(gameObject);
    }
}

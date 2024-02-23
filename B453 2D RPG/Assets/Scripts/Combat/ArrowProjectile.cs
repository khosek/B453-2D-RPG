using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : Projectile
{
    [SerializeField] float arcHeight;
    [SerializeField] float flightTime;

    // Face the tangent of the parabolic curve
    // Parabolic curve

    protected override IEnumerator Fly()
    {
        /* Arc is plotted by
         * Starts at initalposition
         * Ends at target.transform.position
         * so the y value is -(time)^2 + (flighttime/2)*time + the initial position
         * But how will it end at the target's position?
         * We end once we've met the opponent's x value
         */

        Vector3 initialPosition = transform.position;
        float timePassed = 0.0f;

        float xDistanceToTravel = target.transform.position.x - initialPosition.x;

        while (transform.position.x != target.transform.position.x)
        {
            timePassed += Time.deltaTime;
            transform.localPosition = new Vector3(initialPosition.x + xDistanceToTravel * (timePassed/flightTime), initialPosition.y - Mathf.Pow(timePassed, 2) + (flightTime/2) * timePassed, initialPosition.z);
            yield return null;
        }

        target.TakeDamage(damage);

        TurnManager.instance.EndTurn();

        Destroy(gameObject);
    }
}

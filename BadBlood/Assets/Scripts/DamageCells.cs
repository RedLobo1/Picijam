using UnityEngine;

public class DamageCells : MonoBehaviour
{
    [SerializeField] private int _damage;

    public enum States
    {
        None,
        WhiteCell,
        RedCell,
        BlackCell
    }

    [Header("Select Tags to Damage")]
    [SerializeField] private States[] validTargets;  // Array of states to check

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object's tag matches any valid target
        foreach (States state in validTargets)
        {
            if (collision.gameObject.tag == state.ToString())
            {
                GameObject collisionCell = collision.gameObject;

                // Apply damage if the object has a CellHealthLogic component
                CellHealthLogic cellHealth = collisionCell.GetComponent<CellHealthLogic>();
                if (cellHealth != null)
                {
                    cellHealth.TakeDamage(_damage);
                }

                break; // Exit loop after first valid hit
            }
        }
    }
}

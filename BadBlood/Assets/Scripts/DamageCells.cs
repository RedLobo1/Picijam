using UnityEngine;

public class DamageCells : MonoBehaviour
{
    [SerializeField] private int _damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionCell = collision.gameObject;

        if (collisionCell != null)
        {
            if(collisionCell.GetComponent<CellHealthLogic>() != null)
            {
                CellHealthLogic cellHealth = collisionCell.GetComponent<CellHealthLogic>();
                cellHealth.TakeDamage(_damage);
            }
        }
    }
}

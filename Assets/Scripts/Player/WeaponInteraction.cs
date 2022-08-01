using UnityEngine;

namespace Player
{
    public class WeaponInteraction : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(!col.CompareTag(Tags.WEAPON) && col.gameObject.layer == LayerMask.NameToLayer("Fight"))
                Destroy(col.gameObject);
        }
    }
}
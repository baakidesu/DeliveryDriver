using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
        [SerializeField] private float destroyDelay = 0.5f;
        [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
        [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

        bool _hasPackage = false;

        private SpriteRenderer spriteRenderer;

         void Start()
         {
             spriteRenderer = GetComponent<SpriteRenderer>();
         }

        void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Bumped!");
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && _hasPackage == false){
            Debug.Log("Package picked up.");
            _hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            }

        if(other.tag =="Customer" && _hasPackage == true){
            Debug.Log("Package delivered.");
            _hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
    }
}

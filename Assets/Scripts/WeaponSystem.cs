using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] WeaponBase _startingWeaponPrefab = null;
    [SerializeField] WeaponBase _slot01WeaponPrefab = null;
    [SerializeField] WeaponBase _slot02WeaponPrefab = null;
    // weapon socket helps position weapon and graphic
    [SerializeField] Transform _weaponSocket = null;

    [SerializeField] AudioClip _shootSound = null;

    // weapon will use the Strategy Pattern
    // each new weapon will have its own behavior
    public WeaponBase EquippedWeapon{get; private set;}
    private void Awake()
    {
        if(_startingWeaponPrefab != null)
        {
            EquipWeapon(_startingWeaponPrefab);
        }
    }

    private void Update()
    {
        // press 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(_slot01WeaponPrefab);            
        }

        // press 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(_slot02WeaponPrefab);            
        }

        // press Space
        if (Input.GetKeyDown(KeyCode.Space))
            {
            ShootWeapon();
            }
        
    }
     
    public void EquipWeapon(WeaponBase newWeapon)
    {
        if(EquippedWeapon != null)
        {
            Destroy(EquippedWeapon.gameObject);
        }

        // spawn weapon in the world and hold a reference
        EquippedWeapon = Instantiate
             (newWeapon, _weaponSocket.position, _weaponSocket.rotation);
        EquippedWeapon.transform.SetParent(_weaponSocket);
    }

    public void ShootWeapon()
    {
        EquippedWeapon.Shoot();
    }
}

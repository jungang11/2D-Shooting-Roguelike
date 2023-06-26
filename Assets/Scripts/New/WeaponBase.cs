using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class WeaponBase : MonoBehaviour
{
    /*protected static PlayerController PlayerController;

    protected WeaponData.WeaponStats CurrentWeaponStats;
    protected WeaponData.ProjectileStats CurrentProjectileStats;

    private float cooldownTimer;

    private void Awake()
    {
        InitializeProjectilePool();
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        CurrentWeaponStats = weaponData.levelData[0].weaponStats;
        CurrentProjectileStats = weaponData.levelData[0].projectileStats;
    }

    private void Update()
    {
        while(cooldownTimer > CurrentWeaponStats.cooldown)
        {
            Attack();
            cooldownTimer -= CurrentWeaponStats.cooldown;
        }
        cooldownTimer += Time.deltaTime;
    }

    protected abstract void Attack();

    #region Pooling
    protected IObjectPool<WeaponProjectileBase> ProjectilePool;

    private void InitializeProjectilePool()
    {
        ProjectilePool = new ObjectPool<WeaponProjectileBase>(OnCreateProjectile, OnGetProjectile, OnReleaseProjectile);
    }

    private WeaponProjectileBase OnCreateProjectile()
    {
        var projectile = Instantiate(weaponData.projectilePrefab);
        projectile.SetManagedPool(ProjectilePool);
        projectile.projectileStats = CurrentProjectileStats;
        return projectile;
    }

    private static void OnGetProjectile(WeaponProjectileBase projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    private static void OnReleaseProjectile(WeaponProjectileBase projectile)
    {
        projectile.gameObject.SetActive(false);
        //projectile.transform.SetParent(StageManager.Instance.transform, false);
    }

    #endregion

*/
}

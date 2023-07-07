using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public PlayerController player;
    public MonsterSpawn monsterSpawner;

    public Transform spawnPosition;
    public CinemachineVirtualCamera virtualCamera;

    protected override IEnumerator LoadingRoutine()
    {
        progress = 0f;
        GameManager.Pool.Init();
        yield return new WaitForSeconds(0.5f);

        progress = 0.2f;
        GameManager.Sound.Init();
        yield return new WaitForSeconds(0.5f);

        progress = 0.4f;
        GameManager.Data.Init();
        yield return new WaitForSeconds(0.5f);

        progress = 0.6f;
        // 플레이어 생성
        player = GameManager.Resource.Instantiate<PlayerController>("Prefab/Player/Player");
        yield return new WaitForSeconds(0.5f);

        progress = 0.8f;
        // 카메라 배치
        virtualCamera.Follow = player.transform;
        yield return new WaitForSeconds(0.5f);

        progress = 0.9f;
        // 몬스터 스폰
        monsterSpawner = GameManager.Resource.Instantiate<MonsterSpawn>("Prefab/Environment/MonsterSpawnPoints");
        yield return new WaitForSeconds(0.5f);

        progress = 1.0f;
    }
}

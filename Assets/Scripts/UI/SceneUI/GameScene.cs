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
        yield return new WaitForSeconds(0.3f);

        progress = 0.3f;
        GameManager.Data.Init();
        yield return new WaitForSeconds(0.3f);

        progress = 0.4f;
        // �÷��̾� ����
        player = GameManager.Resource.Instantiate<PlayerController>("Prefab/Player/Player");
        yield return new WaitForSeconds(0.3f);

        progress = 0.5f;
        // ī�޶� ��ġ
        virtualCamera.Follow = player.transform;
        yield return new WaitForSeconds(0.3f);

        progress = 0.7f;
        // ���� ����
        monsterSpawner = GameManager.Resource.Instantiate<MonsterSpawn>("Prefab/Environment/MonsterSpawnPoints");
        yield return new WaitForSeconds(0.3f);

        progress = 1.0f;
    }
}

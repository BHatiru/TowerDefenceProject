
using UnityEngine;

public class LazerTower : BaseTower, IUpgradable
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LineRenderer _lineRenderer;
    public void Upgrade()
    {
        Level++;
        TowerData.TowerLevelInfo newLevelInfo = TowerData.UpdageInfo[Level - 1];
        UpdateStats();
        ChangeLevelModel();
    }

    private void Update(){
        

        if(EnemiesInRadius.Count == 0)
            return;

        BaseEnemy target = EnemiesInRadius[0];

        Vector3 localPoint = _attackPoint.transform.InverseTransformPoint(target.transform.position);
        _lineRenderer.SetPosition(1,localPoint);
        Vector3 toEnemyVector = target.transform.position - transform.position;
        float y = toEnemyVector.y;
        toEnemyVector.y = 0;
        _rotateElementHorizontal.right = toEnemyVector;
        toEnemyVector.y = y;
        _rotateElementVertical.right = toEnemyVector;
    }
    
}

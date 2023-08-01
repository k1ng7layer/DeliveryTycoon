using DG.Tweening;
using UnityEngine;

namespace Game.Views.Reward
{
    public class RewardSpawnerView : MonoBehaviour
    {
        [SerializeField] private Transform rewardDestinationTransform;
        [SerializeField] private Transform rewardViewSpawnTransform;
        [SerializeField] private GameObject rewardPrefab;
        [SerializeField] private float moveDuration;
        [SerializeField] private float fadeSpeed;

        public void SpawnReward()
        {
            var spawnPosition = rewardViewSpawnTransform.position;
            var destinationPosition = rewardDestinationTransform.position;
            var rewardObj = Instantiate(rewardPrefab, spawnPosition, rewardPrefab.transform.rotation);

            var renderer = rewardObj.GetComponentInChildren<Renderer>();
            
            rewardObj.transform.DOMoveY(destinationPosition.y, moveDuration).onComplete += () =>
            {
                renderer.material.DOFade(0, fadeSpeed);
            };
        }
    }
}
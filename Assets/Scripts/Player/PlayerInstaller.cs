using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Zenject
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerView>().FromComponentInHierarchy().AsSingle();
        }
    }
}
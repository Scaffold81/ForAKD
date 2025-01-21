using Core.Player;
using Core.UI;
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

            
            Container.Bind<JoystickControllerMove>().FromComponentInHierarchy().AsSingle();

            Container.Bind<JoystickControllerRotate>().FromComponentInHierarchy().AsSingle();
        }
    }
}
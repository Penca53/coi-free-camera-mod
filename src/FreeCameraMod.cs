using Mafi;
using Mafi.Base;
using Mafi.Core;
using Mafi.Core.Mods;
using Mafi.Unity;
using Mafi.Core.Prototypes;
using UnityEngine;

namespace FreeCameraMod
{
    public sealed class FreeCameraMod : IMod
    {
        public string Name => "Free Camera Mod";
        public int Version => 1;
        public bool IsUiOnly => false;

        public FreeCameraMod(CoreMod coreMod, BaseMod baseMod)
        {

        }

        public void Initialize(DependencyResolver resolver, bool gameWasLoaded)
        {
            FreeCameraMenuController cheatMenuController = resolver.Resolve<FreeCameraMenuController>();
            IUnityInputMgr unityInputManager = resolver.Resolve<IUnityInputMgr>();
            unityInputManager.RegisterGlobalShortcut(KeyCode.F7, cheatMenuController);
        }

        public void RegisterPrototypes(ProtoRegistrator registrator)
        {

        }

        public void RegisterDependencies(DependencyResolverBuilder depBuilder, ProtosDb protosDb, bool gameWasLoaded)
        {
            depBuilder.RegisterDependency<FreeCameraMenuController>().AsSelf().AsAllInterfaces();
        }
    }
}

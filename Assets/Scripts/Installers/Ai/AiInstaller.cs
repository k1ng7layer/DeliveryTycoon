using Game.Models.Ai.Impls;
using Game.Models.Ai.Tasks.Default;
using Game.Models.Ai.Tasks.Default.TaskParents;
using Game.Models.Ai.Tasks.SelfState;
using Game.Models.Ai.Tasks.Utils;
using Zenject;

namespace Installers.Ai
{
    public class AiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BehaviourTreeFactory>().AsSingle();
            Container.BindInterfacesTo<AiTaskBuildersLibrary>().AsSingle();

            BindTasks();
        }

        private void BindTasks()
        {
	        Container.BindInterfacesTo<SkipTicksActionBuilder>().AsSingle();
	        Container.BindInterfacesTo<InverterBuilder>().AsSingle();
			Container.BindInterfacesTo<RepeaterBuilder>().AsSingle();
			Container.BindInterfacesTo<ReturnSuccessBuilder>().AsSingle();
			Container.BindInterfacesTo<ReturnFailureBuilder>().AsSingle();
			Container.BindInterfacesTo<SelectorBuilder>().AsSingle();
			Container.BindInterfacesTo<SelectorRandomBuilder>().AsSingle();
			Container.BindInterfacesTo<SelectorRepeaterBuilder>().AsSingle();
			Container.BindInterfacesTo<SequenceBuilder>().AsSingle();
			Container.BindInterfacesTo<ParallelBuilder>().AsSingle();
			Container.BindInterfacesTo<AsyncParallelBuilder>().AsSingle();
			Container.BindInterfacesTo<WaitRandomTimeActionBuilder>().AsSingle();
			Container.BindInterfacesTo<SuccessWithChanceActionBuilder>().AsSingle();
			Container.BindInterfacesTo<WaitTimeActionBuilder>().AsSingle();
			Container.BindInterfacesTo<RepeatAllUntilFailureBuilder>().AsSingle();
        }
    }
}
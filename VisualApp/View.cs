using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Core;

namespace compositionvisual
{
    public class View : IFrameworkView, IFrameworkViewSource
    {
        private Compositor compositor;
        private CompositionTarget compositionTarget;

        static void Main()
        {
            CoreApplication.Run(new View());
        }

        public IFrameworkView CreateView()
        {
            return this;
        }

        public void Initialize(CoreApplicationView applicationView)
        {
            
        }

        public void SetWindow(CoreWindow window)
        {
            compositor = new Compositor();
            compositionTarget = compositor.CreateTargetForCurrentView();

            ContainerVisual container = compositor.CreateContainerVisual();
            compositionTarget.Root = container;

            SpriteVisual visual = compositor.CreateSpriteVisual();
            visual.Size = new Vector2(100, 100);
            visual.Offset = new Vector3(10, 10, 0);
            visual.Brush = compositor.CreateColorBrush(Colors.Red);

            container.Children.InsertAtTop(visual);
            
            ScalarKeyFrameAnimation anim = compositor.CreateScalarKeyFrameAnimation();
            anim.InsertKeyFrame(0.0f, 0.0f);
            anim.InsertKeyFrame(1.0f, 360.0f);
            anim.Duration = TimeSpan.FromSeconds(1);
            anim.IterationBehavior = AnimationIterationBehavior.Forever;
            visual.StartAnimation("RotationAngleInDegrees", anim);
        }

        public void Load(string entryPoint)
        {
            
        }

        public void Run()
        {
            CoreWindow window = CoreWindow.GetForCurrentThread();
            window.Activate();
            window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        }

        public void Uninitialize()
        {
            
        }
    }
}
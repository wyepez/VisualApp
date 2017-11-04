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

            visual = compositor.CreateSpriteVisual();
            visual.Size = new Vector2(100, 100);
            visual.Offset = new Vector3(20, 20, 1);
            visual.Brush = compositor.CreateColorBrush(Color.FromArgb(128, 0, 255, 0));
            
            container.Children.InsertAtTop(visual);
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
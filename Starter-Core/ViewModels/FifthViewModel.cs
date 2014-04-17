using System;
using ReactiveUI;
using System.Reactive.Linq;
using System.Diagnostics;

namespace Starter.Core.ViewModels
{
    public class Color {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        
        public Color(float r, float g, float b) {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
    
    public class FifthViewModel : ReactiveObject
    {
        float _red;
        public float Red {
            get { return _red; }
            set { this.RaiseAndSetIfChanged(ref _red, value); }
        }
        
        float _green;
        public float Green {
            get { return _green; }
            set { this.RaiseAndSetIfChanged(ref _green, value); }
        }

        float _blue;
        public float Blue {
            get { return _blue; }
            set { this.RaiseAndSetIfChanged(ref _blue, value); }
        }

        ObservableAsPropertyHelper<Color> _color;
        public Color Color { get { return _color.Value; } }

        public FifthViewModel()
        {
            var r = this.ObservableForProperty(vm => vm.Red, false, false).Select(x => x.Value);
            var g = this.ObservableForProperty(vm => vm.Green, false, false).Select(x => x.Value);
            var b = this.ObservableForProperty(vm => vm.Blue, false, false).Select(x => x.Value);
            
            _color = Observable.CombineLatest(r, g, b, (x, y, z) => new Color(x, y, z)).ToProperty(this, vm => vm.Color);
            
//            Observable.CombineLatest(r, g, b, (x, y, z) => new Color(x, y, z))
//                .Subscribe(x => Debug.WriteLine(String.Format("{0}/{1}/{2}", x.R, x.G, x.B)));
            
            this.Red = 0;
            this.Green = 0;
            this.Blue = 0;            
        }
    }
}


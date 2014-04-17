using System;
using ReactiveUI;
using Starter.Core.Models;
using System.Windows.Input;
using System.Reactive.Linq;

namespace Starter.Core.ViewModels
{
    public class FourthViewModel : ReactiveObject
    {
        ObservableAsPropertyHelper<LatLon> _location;
        public LatLon Location { get { return _location.Value; } }
        
        public ICommand StartGps { get; private set; }
        
        readonly MyLocationModel _model = new MyLocationModel();
        
        public FourthViewModel()
        {
            var cmd = _model.GpsAvailable().ToCommand();
            
            _location = cmd.SelectMany(_ => _model.GetLocation())
                .ToProperty(this, vm => vm.Location);
            
            this.StartGps = cmd;
        }
    }
}


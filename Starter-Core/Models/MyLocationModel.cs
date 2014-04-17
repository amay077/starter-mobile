using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Starter.Core.Models
{
    public class MyLocationModel {
        
        public IObservable<bool> GpsAvailable() {
            return Observable.Return(true);
        }
        
        public IObservable<LatLon> GetLocation() {
            var r = new System.Random();
            
            return Observable.Interval(TimeSpan.FromSeconds(1))
                    .Select(x => new LatLon(34d + r.NextDouble(), 135d + r.NextDouble()));
        }
    }
}


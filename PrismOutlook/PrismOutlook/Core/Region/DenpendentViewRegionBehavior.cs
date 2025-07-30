using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismOutlook.Core.Region
{
    /// <summary>
    /// 동적 뷰 로직 (Ribbon Control)
    /// </summary>
    public class DenpendentViewRegionBehavior : RegionBehavior
    {
        public const string BehaviorKey = "DependentViewRegionBehavior";
        private readonly IContainerExtension _containerExtension;

        //캐시 추가
        private Dictionary<object, List<DependentViewInfo>> _dependentViewCache = new Dictionary<object, List<DependentViewInfo>>();

        public DenpendentViewRegionBehavior(IContainerExtension containerExtension)
        {
            this._containerExtension = containerExtension;
        }
        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {

                foreach (var newView in e.NewItems)
                {
                    var dependentViews = new List<DependentViewInfo>();

                    if (_dependentViewCache.ContainsKey(newView))
                    {
                        dependentViews = _dependentViewCache[newView];
                    }
                    else
                    {
                        var atts = GetCoustomAttributes<DependentViewAttribute>(newView.GetType());
                        //get attribute
                        foreach (var att in atts)
                        {
                            var info = CreateDependentViewInfo(att);

                            dependentViews.Add(info);
                        }
                        _dependentViewCache.Add(newView, dependentViews);
                    }

                    //inject
                    dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Add(item.View));
                }
            }
            else if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var oldView in e.OldItems)
                {
                    if (_dependentViewCache.ContainsKey(oldView))
                    {
                        var dependentViews = _dependentViewCache[oldView];
                        dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Remove(item.View));

                        if (!ShouldKeepAlive(oldView))
                        {
                            _dependentViewCache.Remove(oldView);
                        }
                    }
                }
            }
        }

        private bool ShouldKeepAlive(object view)
        {
            var regionLifetime = GetViewOrDataContextLifeTime(view);

            if (regionLifetime != null)
                return regionLifetime.KeepAlive;

            return true;
        }

        private IRegionMemberLifetime GetViewOrDataContextLifeTime(object view)
        {
            if (view is IRegionMemberLifetime regionLifetime)
                return regionLifetime;
            if (view is FrameworkElement fe)
                return fe.DataContext as IRegionMemberLifetime;
            return null;
        }

        private DependentViewInfo CreateDependentViewInfo(DependentViewAttribute attribute)
        {
            var info = new DependentViewInfo();
            info.Region = attribute.Region;
            info.View = _containerExtension.Resolve(attribute.Type);
            return info;
        }

        private static IEnumerable<T> GetCoustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }
    }

    public class DependentViewInfo
    {
        public object View { get; set; }
        public string Region { get; set; }
    }
}

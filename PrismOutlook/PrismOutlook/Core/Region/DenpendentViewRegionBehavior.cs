using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Core.Region
{
    /// <summary>
    /// 동적 뷰 로직 (Ribbon Control)
    /// </summary>
    public class DenpendentViewRegionBehavior : RegionBehavior
    {
        public const string BehaviorKey = "DependentViewRegionBehavior";
        private readonly IContainerExtension _containerExtension;

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

                foreach (var view in e.NewItems)
                {
                    var dependentViews = new List<DependentViewInfo>();
                    var atts = GetCoustomAttributes<DependentViewAttribute>(view.GetType());
                    //get attribute
                    foreach (var att in atts)
                    {
                        var info = CreateDependentViewInfo(att);

                        dependentViews.Add(info);
                    }

                    //inject
                    dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Add(item.View));
                }
            }
            else
            {
                
            }
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

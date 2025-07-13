using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Core.Region
{
    public class XamRibbonRegionAdapter: RegionAdapterBase<XamRibbon>
    {
        public XamRibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorfactory) : 
            base(regionBehaviorfactory)
        {
                
        }

        protected override void Adapt(IRegion region, XamRibbon regionTarget)
        {
            region.Views.CollectionChanged += ((s, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        {
                            foreach (var view in e.NewItems)
                            {
                                AddViewToRegion(view, regionTarget);
                            }
                            break;
                        }
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        {
                            foreach (var view in e.OldItems)
                            {
                                RemoveViewFromRegion(view, regionTarget);
                            }
                            break;
                        }
                }
            });
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        static void AddViewToRegion(object view, XamRibbon xamRibbon)
        {
            var ribbonTabItem = view as RibbonTabItem;
            if(ribbonTabItem != null)
                xamRibbon.Tabs.Add(ribbonTabItem);
        }
        static void RemoveViewFromRegion(object view, XamRibbon xamRibbon)
        {
            var ribbonTabItem = view as RibbonTabItem;
            if (ribbonTabItem != null)
                xamRibbon.Tabs.Remove(ribbonTabItem);
        }
    }
}

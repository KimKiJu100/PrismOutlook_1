using Infragistics.Windows.OutlookBar;
using Prism.Regions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Core.Region
{
    public class XamOutlookBarRegionAdapter : RegionAdapterBase<XamOutlookBar>
    {
        public XamOutlookBarRegionAdapter(IRegionBehaviorFactory regionBehaviorfactory) :
             base(regionBehaviorfactory) 
        {
            
        }
        protected override void Adapt(IRegion region, XamOutlookBar regionTarget)
        {
            region.Views.CollectionChanged += ((s, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        {
                            foreach (OutlookBarGroup group in e.NewItems)
                            {
                                regionTarget.Groups.Add(group);

                                //The WPF XamOutlookBar does not automatically select the first group in it's collection.
                                //So we must manually select the group if it is the first one in the collection, but we don't 
                                //want to excute this code every time a new group is added, only if the first group is the current group being added.
                                if (regionTarget.Groups[0] == group)
                                {
                                    regionTarget.SelectedGroup = group;
                                }
                            }
                            break;
                        }
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        {
                            foreach (OutlookBarGroup group in e.OldItems)
                            {
                                regionTarget.Groups.Remove(group);
                            }
                            break;
                        }
                }
            });
        }

        protected override IRegion CreateRegion()
        {
            //3가지 생명 주기가 있음.
            //Single Active Region          활성화 1개뷰 레전
            //AllActiveRegion               활성화 여러개 뷰 레전
            //Region                        활성화 사용자 커스텀 레전 
            return new SingleActiveRegion();
        }
    }
}

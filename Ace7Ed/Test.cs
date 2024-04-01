using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI.PropertyTypes.Objects;
using UAssetAPI.UnrealTypes;

namespace Ace7Ed
{
    public class Test
    {
        private PropertyData _propertyData = null;

        public Test(PropertyData propertyData)
        {
            _propertyData = propertyData;
        }

        [Category("Primary")]
        public FName Name => _propertyData.Name;
    }
}

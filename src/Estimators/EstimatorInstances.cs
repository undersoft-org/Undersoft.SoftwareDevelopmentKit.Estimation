using System;
using System.Collections.Generic;
using System.Text;

namespace Undersoft.SDK.Estimation.Estimators
{
    public static class EstimatorInstances
    {
        public static object New(string strFullyQualifiedName)
        {
            return Instances.New(strFullyQualifiedName);
        }
    }
}

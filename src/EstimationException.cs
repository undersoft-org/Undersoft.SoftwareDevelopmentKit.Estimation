using System;
using System.Collections.Generic;
using System.Text;

namespace Undersoft.SDK.Estimation
{
    public class EstimationException : Exception
    {
        public EstimationException(EstimationExceptionList exceptionList)
           : base(EstimationExceptionRegistry.Registry[exceptionList])
        {

        }
    }

    public static class EstimationExceptionRegistry
    {
        public static Dictionary<EstimationExceptionList, string> Registry =
            new Dictionary<EstimationExceptionList, string>()
        {
            {EstimationExceptionList.DataType, "Wrong input data type" },
            {EstimationExceptionList.DataTypeSingle, "Wrong data type: input X or Y is not a single column" },
            {EstimationExceptionList.DataTypeConvertDouble, "Wrong data type: input cannot be converted to double" },
            {EstimationExceptionList.DataTypeInconsistentXY, "Wrong data type: input X inconsistent with Y" },
            {EstimationExceptionList.InputParameterInconsistent, "Input inconsistent estimator parameter size" },
            {EstimationExceptionList.MethodCannotBeProceeded, "Method cannot be proceeded for this estimator" },
            {EstimationExceptionList.Error, "Error - System Crash" }
        };

    }

    public enum EstimationExceptionList
    {
        DataType,
        DataTypeSingle,
        DataTypeConvertDouble,
        DataTypeInconsistentXY,
        InputParameterInconsistent,
        MethodCannotBeProceeded,
        Error
    }
}

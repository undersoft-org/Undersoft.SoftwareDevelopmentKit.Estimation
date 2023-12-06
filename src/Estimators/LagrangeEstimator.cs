using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Undersoft.SDK.Estimation.Estimators
{
    using Undersoft.SDK.Series;

    public class LagrangeEstimator : Estimator
    {
        public override void Prepare(EstimatorInput<EstimatorSeries, EstimatorSeries> input)
        {
            validInput = false;
            //only one dimension
            if (input.X.Count > 0 && input.X[0].Vector.Length > 1 ||
                input.Y.Count > 0 && input.Y[0].Vector.Length > 1) throw new EstimationException(EstimationExceptionList.DataTypeSingle);
            Input = input;
            validInput = true;
        }

        public override void Prepare(EstimatorSeries x, EstimatorSeries y)
        {
            Prepare(new EstimatorInput<EstimatorSeries, EstimatorSeries>(x, y));
        }

        public override EstimatorItem Evaluate(object x)
        {
            return Evaluate(new EstimatorItem(x));
        }

        public override void Create()
        {

        }

        public override EstimatorItem Evaluate(EstimatorItem x)
        {
            if (!validInput) throw new EstimationException(EstimationExceptionList.DataType);

            double t;
            double y = 0.0;

            var a = Input.X.Select((x0, k) => Input.X.Select((x1, j) => x1).ToList()).ToList();

            for (int k = 0; k < Input.X.Count; k++)
            {
                t = 1.0;
                for (int j = 0; j < Input.X.Count; j++)
                {
                    if (j != k)
                    {
                        t = t * ((x.Vector[0] - Input.X[j].Vector[0]) / (Input.X[k].Vector[0] - Input.X[j].Vector[0]));
                    }
                }

                y += t * Input.Y[k].Vector[0];
            }

            return new EstimatorItem(y);
        }

        public override void Update(EstimatorInput<EstimatorSeries, EstimatorSeries> input)
        {
            throw new EstimationException(EstimationExceptionList.MethodCannotBeProceeded);
        }

        public override void Update(EstimatorSeries x, EstimatorSeries y)
        {
            throw new EstimationException(EstimationExceptionList.MethodCannotBeProceeded);
        }

        public override double[][] GetParameters()
        {
            return null;
        }

    }

}

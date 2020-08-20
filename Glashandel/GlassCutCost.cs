using System;
using System.Collections.Generic;

namespace Glashandel
{
    internal class GlassCutCost
    {
        private const int percentageTotal = 100;

        private const string glassTypeOneName = "normal glass";
        private const int glassTypeOneCostPerCubicMeter = 30;
        private const int glassTypeOneCostCut = 10;
        private const string glassTypeTwoName = "special glass";
        private const int glassTypeTwoCostPerCubicMeter = 55;
        private const int glassTypeTwoCostCut = 25;

        private const int upperLimitCutCost = 145;
        private const int persentageReductionThreshold = 250;
        private const int percentageReduction = 5;

        private static List<GlassType> glassTypes;

        internal static string[] GetTypeOptions()
        {
            SetupGlassTypes();
            string[] toReturn = new string[glassTypes.Count];
            for(int i = 0; i < toReturn.Length; i++)
            {
                toReturn[i] = glassTypes[i].GetName();
            }
            return toReturn;
        }
        internal static double GetCost(double surfase, string type, bool canBeMadeFromRemainingMaterial)
        {
            SetupGlassTypes();
            foreach (GlassType glassType in glassTypes)
            {
                if (glassType.IsSameName(type))
                {
                    if (canBeMadeFromRemainingMaterial == false)
                    {
                        surfase = Math.Ceiling(surfase);
                    }
                    double cost = glassType.GetCostPerCubicMeter() * surfase;
                    if (cost < upperLimitCutCost)
                    {
                        cost += glassType.GetCostCut();
                    }
                    if (cost >= persentageReductionThreshold)
                    {
                        cost *= 1.0 / percentageTotal * (percentageTotal - percentageReduction);
                    }
                    return cost;
                }
            }
            throw new NotImplementedException();
        }
        private static void SetupGlassTypes()
        {
            if (glassTypes == null)
            {
                glassTypes = new List<GlassType>();
                glassTypes.Add(new GlassType(glassTypeOneName, glassTypeOneCostPerCubicMeter, glassTypeOneCostCut));
                glassTypes.Add(new GlassType(glassTypeTwoName, glassTypeTwoCostPerCubicMeter, glassTypeTwoCostCut));
            }
        }

        private class GlassType
        {
            private string name;
            private int costPerCubicMeter;
            private int costCut;
            
            internal GlassType(string name, int costPerCubicMeter, int costCut)
            {
                this.name = name;
                this.costPerCubicMeter = costPerCubicMeter;
                this.costCut = costCut;
            }
            internal string GetName()
            {
                return name;
            }
            internal bool IsSameName(string name)
            {
                return this.name.Equals(name);
            }
            internal int GetCostPerCubicMeter()
            {
                return costPerCubicMeter;
            }
            internal int GetCostCut()
            {
                return costCut;
            }
        }
    }
}
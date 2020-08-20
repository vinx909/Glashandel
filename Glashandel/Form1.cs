using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glashandel
{
    public partial class Form1 : Form
    {
        private const string glassSurfaseSizeString = "surfase of the glass im square meters";
        private const string glassRemainingMaterialString = "can be made from remaining glass";
        private const string calculateCostButtonString = "calculate the cost of the glass";
        private const string messageBoxPresentPriceString = "the cost of the cut glass is ";

        private const int widthMargin = 10;
        private const int heightMargin = 10;
        private const int rowHeight = 30;
        private const int elementLength = 150;

        private TextBoxWithLabelFormElement glassSurfaseSize;
        private RadioButtonsFormElement glassType;
        private CheckBoxFormElement glassRemainingMaterial;
        private ButtonFormElement calculateCostButton;

        public Form1()
        {
            InitializeComponent();
            InitializeElements();
            ResetPosition();
        }
        private void InitializeElements()
        {
            glassSurfaseSize = new TextBoxWithLabelFormElement(this, glassSurfaseSizeString);
            glassSurfaseSize.SetTextBoxOfset(elementLength);
            glassType = new RadioButtonsFormElement(this, GlassCutCost.GetTypeOptions(), rowHeight);
            glassRemainingMaterial = new CheckBoxFormElement(this, glassRemainingMaterialString);
            glassRemainingMaterial.SetWidth(elementLength);
            calculateCostButton = new ButtonFormElement(this, calculateCostButtonString, CalculateCostButtonFunction);
        }
        private void ResetPosition()
        {
            int row = 0;
            glassSurfaseSize.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            glassType.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row += glassType.GetAmountOfRows();
            glassRemainingMaterial.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            calculateCostButton.ChangePosition(widthMargin, heightMargin + rowHeight * row);
        }

        private void PresentCost()
        {
            double surfase = glassSurfaseSize.GetValueAsDouble();
            string type = glassType.GetValue();
            bool canBeMadeFromRemainingMaterial = glassRemainingMaterial.GetValue();
            double toPresent = GlassCutCost.GetCost(surfase, type, canBeMadeFromRemainingMaterial);
            MessageBox.Show(messageBoxPresentPriceString + toPresent);
        }

        private void CalculateCostButtonFunction(object sender, EventArgs e)
        {
            PresentCost();
        }
    }
}

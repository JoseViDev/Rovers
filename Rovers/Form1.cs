using NasaMars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rovers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // fields are initialized
            cbDirection.Items.Add(Directions.North);
            cbDirection.Items.Add(Directions.East);
            cbDirection.Items.Add(Directions.South);
            cbDirection.Items.Add(Directions.West);
            cbDirection.SelectedIndex = 0;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            // grid information is parsed and grid fields are populated
            InputParser.ParseGrid(txtInput.Text);
            txtGridLimitX.Text = Grid.Instance.LimitX.ToString();
            txtGridLimitY.Text = Grid.Instance.LimitY.ToString();

            // rover information is parsed
            lbOperations.Items.Clear();
            lbOperations.Items.AddRange(InputParser.ParseTours(txtInput.Text).ToArray());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // creates required objects for each rover
            Tour tour = new Tour();
            tour.Vehicle = new Rover();
            tour.Vehicle.X = int.Parse(txtRoverX.Text);
            tour.Vehicle.Y = int.Parse(txtRoverY.Text);
            tour.Vehicle.Direction = (Directions)cbDirection.SelectedItem;
            tour.Instructions = InputParser.ParseInstructions(txtInstructions.Text);

            lbOperations.Items.Add(tour);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // created or updatesthe grid
            Grid.Instance.LimitX = int.Parse(txtGridLimitX.Text);
            Grid.Instance.LimitY = int.Parse(txtGridLimitY.Text);

            // execure rovers
            List<Tour> operations = lbOperations.Items.Cast<Tour>().ToList();
            txtOutput.Text = VehicleManager.Execute(operations);
        }

    }
}

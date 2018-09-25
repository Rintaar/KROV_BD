using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Core.DatabaseTableClass;

namespace WindowsFormsApp1.Forms
{
    public partial class WaitingForm : Form
    {
        public Action Worker { get; set; }
        public WaitingForm(Action worker)
        {

            InitializeComponent();
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;
        }
        public WaitingForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        internal void ShowDialog(BudgetTable budgetTable)
        {
            throw new NotImplementedException();
        }
    }
}

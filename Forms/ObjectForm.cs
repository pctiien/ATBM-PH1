using System;
using System.Linq;
using System.Windows.Forms;
using ATBM_HTTT_PH1.Service;

namespace ATBM_HTTT_PH1.Forms
{
    public partial class ObjectForm : Form
    {
        private readonly IObjectService objectService;

        public ObjectForm(IObjectService objectService)
        {
            InitializeComponent();
            this.objectService = objectService;
        }

        private async void comboBoxObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedType = comboBoxObjectType.SelectedItem?.ToString();
            if (selectedType!=null)
            {
                var data = await objectService.getObjectByType(selectedType);

                dataGridViewObjects.DataSource = data
                    .Select(row => new
                    {
                        ObjectName = row[0],
                        Owner = row[1],
                        CreatedDate = row[2]
                    })
                    .ToList();
            }
            
        }
    }
}

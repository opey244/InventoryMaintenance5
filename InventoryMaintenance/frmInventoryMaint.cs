namespace InventoryMaintenance
{
    public partial class frmInventoryMaint : Form
    {
        // Opey Obute
        public frmInventoryMaint()
        {
            InitializeComponent();
        }

        private List<InventoryItem> items = null!;

        // Opey Obute
        private void frmInventoryMaint_Load(object sender, EventArgs e)
        {
            items = InventoryDB.GetItems();
            LoadComboBox();
            FillItemListBox();
        }

        // Opey Obute
        private void LoadComboBox()
        {
            cboFilterBy.DataSource = new string[] {
                "All", "Under $10", "$10 to $50", "Over $50"
            };
        }

        // Opey Obute
        private void FillItemListBox()
        {
            lstItems.Items.Clear();

            string filter = cboFilterBy.SelectedValue?.ToString() ?? "";
            IEnumerable<InventoryItem> filteredItems;

            if (filter == "Under $10")
            {
                filteredItems = items.Where(item => item.Price < 10m)
                                     .OrderBy(item => item.Description);
            }
            else if (filter == "$10 to $50")
            {
                filteredItems = items
                    .Where(item => item.Price >= 10m && item.Price <= 50m)
                    .OrderBy(item => item.Description);
            }
            else if (filter == "Over $50")
            {
                filteredItems = items.Where(item => item.Price > 50m)
                                     .OrderBy(item => item.Description);
            }
            else
            {
                filteredItems = items.OrderBy(item => item.Description);
            }

            foreach (InventoryItem item in filteredItems)
            {
                lstItems.Items.Add(item.GetDisplayText());
            }
        }

        // Opey Obute
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewItem newItemForm = new();
            InventoryItem item = newItemForm.GetNewItem();
            if (item != null)
            {
                items.Add(item);
                InventoryDB.SaveItems(items);
                FillItemListBox();
            }
        }

        // Opey Obute
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;

            if (i == -1)
            {
                MessageBox.Show("Please select an item to delete.", "No item selected");
            }
            else
            {
                string displayText = lstItems.Items[i].ToString()!;
                InventoryItem item = items
                    .First(item => item.GetDisplayText() == displayText);

                string message = $"Are you sure you want to delete {item.Description}?";
                DialogResult result =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    items.Remove(item);
                    InventoryDB.SaveItems(items);
                    FillItemListBox();
                }
            }
        }

        // Opey Obute
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Opey Obute
        private void cboFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillItemListBox();
        }
    }
}
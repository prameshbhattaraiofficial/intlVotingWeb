using static VotingAdmin.Web.Dtos.PageModel.PageModel;

namespace VotingAdmin.Web.Dtos.PageModel
{
    public class SortModels
    {
        //private string sortIconUp = "fa fa-long-arrow-up";
        //private string sortIcondown = "fa fa-long-arrow-down";
        private string sortIcondowncolor = "color:Gray";
        private string sortIconUpcolor = "Color:orange";
        private string sortIconUp = "fas fa-sort-alpha-up-alt";
        private string sortIcondown = "fas fa-sort-alpha-down";
        public string SortedProperty { get; set; }
        public sortOrder SortedOrder { get; set; }
        private List<SortableColumns> sortableColumns = new List<SortableColumns>();
        public void AddColumn(string columns, bool IsdefaultColumn = false)
        {
            SortableColumns temp = sortableColumns.Where(x => x.ColumnName.ToLower() == columns.ToLower()).SingleOrDefault();
            if (temp == null)
            {
                sortableColumns.Add(new SortableColumns { ColumnName = columns });
            }
            if (IsdefaultColumn == true || sortableColumns.Count == 1)
            {
                SortedProperty = columns;
                SortedOrder = sortOrder.Ascending;
            }
        }
        public SortableColumns GetColumn(string columns)
        {
            SortableColumns temp = sortableColumns.Where(x => x.ColumnName.ToLower() == columns.ToLower()).SingleOrDefault();
            if (temp == null)
            {
                sortableColumns.Add(new SortableColumns { ColumnName = columns });
            }
            return temp;
        }

        public void Applysorts(string sortexpression)
        {
            if (sortexpression == "")
            {
                sortexpression = SortedProperty;
            }
            sortexpression = sortexpression.ToLower();
            foreach (SortableColumns sortablecolumn in sortableColumns)
            {
                sortablecolumn.SortIcon = "";
                sortablecolumn.SortExpression = sortablecolumn.ColumnName;
                if (sortexpression == sortablecolumn.ColumnName.ToLower())
                {
                    SortedOrder = sortOrder.Ascending;
                    SortedProperty = sortablecolumn.ColumnName;
                    sortablecolumn.SortIcon = sortIcondown;
                    sortablecolumn.SortIconColor = sortIcondowncolor;
                    sortablecolumn.SortExpression = sortablecolumn.ColumnName + "_desc";
                }
                if (sortexpression == sortablecolumn.ColumnName.ToLower() + "_desc")
                {
                    SortedOrder = sortOrder.Descending;
                    SortedProperty = sortablecolumn.ColumnName;
                    sortablecolumn.SortIcon = sortIconUp;
                    sortablecolumn.SortIconColor = sortIconUpcolor;
                    sortablecolumn.SortExpression = sortablecolumn.ColumnName;
                }
            }

        }

        //internal void Applysorts(object sortExpression)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class SortableColumns
    {
        public string ColumnName { get; set; }
        public string SortExpression { get; set; }
        public string SortIcon { get; set; }
        public string SortIconColor { get; set; }
    }
}

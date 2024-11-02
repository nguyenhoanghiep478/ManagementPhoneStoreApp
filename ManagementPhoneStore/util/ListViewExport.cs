using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
namespace ManagementPhoneStore.util
{
    public class ListViewExport
    {
        public static void ExportListViewToExcel(ListView listView)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn đường dẫn lưu file Excel";
                saveFileDialog.Filter = "XLSX files|*.xlsx";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    IWorkbook workbook = new XSSFWorkbook();
                    ISheet sheet = workbook.CreateSheet("Sheet1");

                    // Tạo dòng tiêu đề
                    IRow headerRow = sheet.CreateRow(0);
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        ICell headerCell = headerRow.CreateCell(i);
                        headerCell.SetCellValue(listView.Columns[i].Text);
                    }

                    // Tạo các dòng dữ liệu
                    for (int i = 0; i < listView.Items.Count; i++)
                    {
                        IRow dataRow = sheet.CreateRow(i + 1);
                        ListViewItem item = listView.Items[i];

                        for (int j = 0; j < item.SubItems.Count; j++)
                        {
                            ICell dataCell = dataRow.CreateCell(j);
                            dataCell.SetCellValue(item.SubItems[j].Text);
                        }
                    }

                    // Điều chỉnh kích thước các cột cho vừa nội dung
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }

                    // Ghi file
                    using (FileStream fileOut = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(fileOut);
                    }

                    workbook.Close();
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

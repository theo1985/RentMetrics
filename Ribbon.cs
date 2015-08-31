using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using RentMetrics.Properties;

namespace RentMetrics
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            //UDF u = new UDF();
            SetupButtons();
            fHelp.FormClosing += fHelp_FormClosing;
        }

        private void SetupButtons()
        {
            btnAPI.Label = (String.IsNullOrWhiteSpace(Reg.API) ? "Click to Enter Access Token" : "Change Access Token");
            btnAPI.Image = (String.IsNullOrWhiteSpace(Reg.API) ? Resources.close_icon : Resources.Accept_icon);
        }

        private void btnAPI_Click(object sender, RibbonControlEventArgs e)
        {
            using (FormAPI f = new FormAPI())
            {
                f.ShowDialog();
                SetupButtons();
            }
        }

        FormHelp fHelp = new FormHelp();
        private void btnHelp_Click(object sender, RibbonControlEventArgs e)
        {
            fHelp.Show();
        }

        void fHelp_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = true;
            fHelp.Hide();
        }

        private void btnFormula_Click(object sender, RibbonControlEventArgs e)
        {
            var cell = Globals.ThisAddIn.Application.ActiveCell;

            cell.Formula = "=1+1";

            return;

            var cellValue = Globals.ThisAddIn.Application.ActiveCell.Value;
            Globals.ThisAddIn.Application.ActiveCell.Value = "THEO";
            return;
            Globals.ThisAddIn.Application.ActiveCell.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, "Theo_");
        }

        private void btnHomes_Click(object sender, RibbonControlEventArgs e)
        {
            using (FormSearch fs = new FormSearch(true))
            {
                if (fs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Globals.ThisAddIn.Application.Worksheets.Add();
                    Display(fs.d, Globals.ThisAddIn.Application.ActiveCell, true);
                }
            }
        }

        private void btnApartments_Click(object sender, RibbonControlEventArgs e)
        {
            using (FormSearch fs = new FormSearch(false))
            {
                if (fs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Globals.ThisAddIn.Application.Worksheets.Add();
                    Display(fs.d, Globals.ThisAddIn.Application.ActiveCell, false);
                }
            }
        }

        private void Display(dynamic d, Microsoft.Office.Interop.Excel.Range cell, Boolean isHomes)
        {
            List<object> a = d.collection;

            FormProgress bar = new FormProgress();
            bar.bar.Maximum = a.Count;
            //bar.bar.Step = 1;
            bar.Show();

            var fsdfsdf = (a[0] as RentMetrics.DynamicJsonConverter.DynamicJsonObject).ToDic();

            Int32 _row = cell.Row, _col = cell.Column;
            foreach (var k in fsdfsdf)
            {
                if (k.Key == "neighborhood")
                    continue;

                SortOrder.Add(k.Key);

                if (k.Key != "latest_prices")
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = k.Key.Replace("_", " ");
                else
                {
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "bedrooms";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "full bathrooms";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "partial bathrooms";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "sq ft";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "rent";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "rent per sq ft";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "concession type";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "concession value";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "eff rent";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "eff rent per sq ft";
                    Globals.ThisAddIn.Application.Cells[_row, _col++].Value = "rent posted date";
                }
            }

            for (int i = 0; i < a.Count; i++)
            {
                bar.bar.PerformStep();

                _row++;
                _col = cell.Column;

                var tmp = (a[i] as RentMetrics.DynamicJsonConverter.DynamicJsonObject).ToDic();

                ArrayList s = new ArrayList();
                foreach (var k in tmp)
                {
                    if (!isHomes)
                    {
                        if (SortOrder.IndexOf(k.Key) > SortOrder.IndexOf("sq_ft_lot"))
                            _col = SortOrder.IndexOf(k.Key) - 1;
                        else if (SortOrder.IndexOf(k.Key) > SortOrder.IndexOf("latest_prices"))
                            _col = SortOrder.IndexOf(k.Key);
                        else
                            _col = SortOrder.IndexOf(k.Key) + 1;
                    }

                    if (k.Value == null && (SortOrder.IndexOf(k.Key) != SortOrder.Count - 1))
                    {
                        _col++;
                        continue;
                    }
                    else if (k.Key == "latest_prices")
                    {
                        s = k.Value as ArrayList;
                        _col++;
                    }
                    else if (k.Value is ArrayList)
                    {
                        var strings = (k.Value as ArrayList).Cast<string>().ToArray();
                        Globals.ThisAddIn.Application.Cells[_row, _col++].Value = String.Join(", ", strings);
                    }
                    else if (SortOrder.IndexOf(k.Key) == SortOrder.Count - 1)
                    {
                        //Globals.ThisAddIn.Application.Cells[_row, _col++].Value = FormatResponse(k);
                        
                        Int32 MaxCol = _col + 1;
                        for (int j = 0; j < s.Count; j++) // for each latest_price
                        {
                            var ks = (s[j] as Dictionary<String, Object>).Keys;

                            if (j > 0)
                            {
                                _row++;
                                for (var t = 1; t <= MaxCol; t++)
                                {
                                    if (!ks.Contains(SortOrder.AtIndex(t - 1)))
                                        Globals.ThisAddIn.Application.Cells[_row, t].Value = Globals.ThisAddIn.Application.Cells[_row - 1, t].Value;
                                }
                            }

                            foreach (var t in (s[j] as Dictionary<String, Object>))
                            {
                                if (t.Value == null)
                                    continue;

                                Globals.ThisAddIn.Application.Cells[_row, SortOrder.IndexOf(t.Key)].Value = FormatResponse(t);
                            }
                        }
                    }
                    else
                    {
                        if (k.Key == "rent_posted_date")
                            Globals.ThisAddIn.Application.Cells[_row, _col].NumberFormat = "mm/dd/yyyy";

                        Globals.ThisAddIn.Application.Cells[_row, _col++].Value = FormatResponse(k);
                    }
                }
            }

            Globals.ThisAddIn.Application.ActiveWindow.SplitRow = 1;
            Globals.ThisAddIn.Application.ActiveWindow.FreezePanes = true;

            Microsoft.Office.Interop.Excel.Range firstRow = (Microsoft.Office.Interop.Excel.Range)Globals.ThisAddIn.Application.Rows[1];
            firstRow.Select();
            firstRow.AutoFilter(1, Type.Missing, Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);

            Globals.ThisAddIn.Application.Columns.AutoFit();

            bar.Hide();
        }

        private String FormatResponse(KeyValuePair<String, Object> k)
        {
            switch (k.Key)
            {
                case "rent":
                case "rent_per_sq_ft":
                case "eff_rent":
                case "eff_rent_per_sq_ft":
                    return ((Decimal)k.Value).ToString("C", new CultureInfo("en-US"));

                case "distance_mi":
                    return ((Decimal)k.Value).ToString("N2", new CultureInfo("en-US"));

                case "sq_ft":
                case "sq_ft_lot":
                    return ((Decimal)k.Value).ToString("N0", new CultureInfo("en-US"));

                default:
                    return k.Value.ToString();
            }
        }
    }
}

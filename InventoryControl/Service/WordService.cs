using InventoryControl.BdWork;
using InventoryControl.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;

namespace InventoryControl.Service
{
    public class WordService
    {
        private FileInfo _fileInfo;
        public WordService(string filename)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Выберите темплейт ворда(WordTemplate)";
            fbd.SelectedPath = System.IO.Directory.GetCurrentDirectory();
         

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fbd.SelectedPath + "\\TemplateDocladnay.docx"))
                {

                    _fileInfo = new FileInfo(fbd.SelectedPath  + "\\TemplateDocladnay.docx");
                }
                else
                {
                    throw new ArgumentException("File not found");
                }
            }
           
            
        }
        internal bool Process(ComingRecords recorsOfСoming)
        {
           word.Application app = null;

            try
            {
                app = new word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file);
                var items = new Dictionary<string, string>()
                {
                    {"[postavshik]", "DNS"},
                    {"[gruzoPoluchatel]", recorsOfСoming.Employers.FioEmp},
                    {"[AdressGruzoPoluchatel]", "Орехово-зуево, ул ленина 44, д. 12, корпус 1" },
                    {"[NumberDoc]", recorsOfСoming.NumberOfNakladnay },
                    {"[dataDoc]", recorsOfСoming.DateChanging.ToString() }

                };
                foreach( var item in items )
                {
                    word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;
                    Object wrap = word.WdFindWrap.wdFindContinue;
                    Object replace = word.WdReplace.wdReplaceAll;
                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false
                        , ReplaceWith: missing, Replace: replace);
                }
                word.Table table = app.ActiveDocument.Tables[1];
                int index = 2;
                    table.Rows.Add(missing);
                    table.Cell(index, 1).Range.Text = recorsOfСoming.NumberOfNakladnay.ToString();
                    table.Cell(index, 2).Range.Text = recorsOfСoming.Equipment.name;
                    table.Cell(index, 3).Range.Text = recorsOfСoming.Equipment.id_equip.ToString();
                    table.Cell(index, 4).Range.Text = recorsOfСoming.CountEquip.ToString();
                    table.Cell(index, 5).Range.Text = recorsOfСoming.Equipment.Brutto.ToString();
                    table.Cell(index, 6).Range.Text = recorsOfСoming.Equipment.Netto.ToString();
                    table.Cell(index, 7).Range.Text = "Коробка";
                    table.Cell(index, 8).Range.Text = "45000";
                System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

                saveFileDialog1.Filter = "Word document|*.doc";

                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Object newFileName = saveFileDialog1.FileName;
                    app.ActiveDocument.SaveAs2(newFileName);
                    app.ActiveDocument.Close();
                    return true;
                }

                 
               
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(app != null)
                {
                    app.Quit();
                }
            }
            return false;

        }
    }
}

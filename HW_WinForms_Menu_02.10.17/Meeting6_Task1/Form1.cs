using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Meeting6_Task1
{
    public partial class TextEditor : Form
    {
        public TextEditor()
        {
            InitializeComponent();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            fontDialog.ShowColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = this.BackColor;
        }

        private string filename;
        private string fileText;
        private TextEditor textEditor;
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog.FileName;
            fileText = File.ReadAllText(filename);
            richTextBox.Text = fileText;
        }
        
        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            filename = saveFileDialog.FileName;
            File.WriteAllText(filename, richTextBox.Text);
        }

        private void CreateMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.TextLength != 0)
            {
                DialogResult res = MessageBox.Show("Текстовый редактор содержит текст. Сохранить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(saveFileDialog.FileName, richTextBox.Text);
                }
                else if (res == DialogResult.No)
                    richTextBox.Clear();
            }
        }
        
        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
                richTextBox.Copy();
        }
        
        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
                richTextBox.Cut();
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (richTextBox.SelectionLength > 0)
                     richTextBox.SelectionStart = richTextBox.SelectionStart + richTextBox.SelectionLength;
                richTextBox.Paste();
            }
        }

        private void UndoMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.CanUndo)
            {
                richTextBox.Undo();
                richTextBox.ClearUndo();
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FontColorMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.Cancel)
                return;
            
            else if (richTextBox.SelectionLength > 0)
                richTextBox.SelectionColor = fontDialog.Color;
            else richTextBox.ForeColor = fontDialog.Color;
        }

        private void FontMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.Cancel)
                return;
            else if (richTextBox.SelectionLength > 0)
                richTextBox.SelectionFont = fontDialog.Font;
            else richTextBox.Font = fontDialog.Font;
        }

        private void BackColorMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            richTextBox.BackColor = colorDialog.Color;
        }

        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.TextLength > 0)
                richTextBox.SelectAll();
        }

        private void CopyContextMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
                richTextBox.Copy();
        }

        private void CutContextMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
                richTextBox.Cut();
        }

        private void PasteContextMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (richTextBox.SelectionLength > 0)
                    richTextBox.SelectionStart = richTextBox.SelectionStart + richTextBox.SelectionLength;
                richTextBox.Paste();
            }
        }

        private void UndoContextMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.CanUndo)
            {
                richTextBox.Undo();
                richTextBox.ClearUndo();
            }
        }
    }
}

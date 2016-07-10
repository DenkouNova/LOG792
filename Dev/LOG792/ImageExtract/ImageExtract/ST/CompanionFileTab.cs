using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageExtract.ST
{
    public partial class CompanionFileTab : UserControl
    {
        private enum CompanionFileType
        {
            NoFile, CSV, FixedLength, Custom
        }

        private CompanionFileType currentlyDisplayedOptions = CompanionFileType.NoFile;

        CompanionFileOptionsNoFile optionsNoFile = null;
        CompanionFileOptionsCSV optionsCsv = null;
        CompanionFileOptionsFixedLength optionsFixedLength = null;
        CompanionFileOptionsCustomClass optionsCustomClass = null;




        public CompanionFileTab()
        {
            InitializeComponent();
        }

        private void CompanionFileType_CheckedChanged(object sender, EventArgs e)
        {
            bool optionsTypeChanged = false;

            if (this.rbNoAccompanyingFile.Checked && currentlyDisplayedOptions != CompanionFileType.NoFile)
            {
                optionsTypeChanged = true;
                currentlyDisplayedOptions = CompanionFileType.NoFile;
            }
            else if (this.rbCSVFile.Checked && currentlyDisplayedOptions != CompanionFileType.CSV)
            {
                optionsTypeChanged = true;
                currentlyDisplayedOptions = CompanionFileType.CSV;
            }
            else if (this.rbFixedLengthFieldsFile.Checked && currentlyDisplayedOptions != CompanionFileType.FixedLength)
            {
                optionsTypeChanged = true;
                currentlyDisplayedOptions = CompanionFileType.FixedLength;
            }
            else if (this.rbCustomFile.Checked && currentlyDisplayedOptions != CompanionFileType.Custom)
            {
                optionsTypeChanged = true;
                currentlyDisplayedOptions = CompanionFileType.Custom;
            }


            if (optionsTypeChanged)
            {
                foreach(Control c in panel2.Controls) panel2.Controls.Remove(c);
                optionsNoFile = null;
                optionsCsv = null;
                optionsFixedLength = null;
                optionsCustomClass = null;
                LoadNewOptions();
            }
        }


        private void LoadNewOptions()
        {
            if (currentlyDisplayedOptions == CompanionFileType.NoFile)
            {
                optionsNoFile = new CompanionFileOptionsNoFile();
                this.panel2.Controls.Add(optionsNoFile);
            }
            else if (currentlyDisplayedOptions == CompanionFileType.CSV)
            {
                optionsCsv = new CompanionFileOptionsCSV();
                this.panel2.Controls.Add(optionsCsv);
            }
            else if (currentlyDisplayedOptions == CompanionFileType.FixedLength)
            {
                optionsFixedLength = new CompanionFileOptionsFixedLength();
                this.panel2.Controls.Add(optionsFixedLength);
            }
            else if (currentlyDisplayedOptions == CompanionFileType.Custom)
            {
                optionsCustomClass = new CompanionFileOptionsCustomClass();
                this.panel2.Controls.Add(optionsCustomClass);
            }
        }


    }
}

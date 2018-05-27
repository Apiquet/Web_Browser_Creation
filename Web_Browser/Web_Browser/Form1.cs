using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public partial class WebBrowserForm : Form
    {
        public WebBrowserForm()
        {
            InitializeComponent();
        }
        //web browser declaration
        private WebBrowser _web = new WebBrowser();
        //tab index
        private int _i = 0;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //set up program when the from load
        private void Form1_Load(object sender, EventArgs e)
        {
            _web = new WebBrowser();
            //The tab window needs to fill the form
            _web.Dock = DockStyle.Fill;
            _web.DocumentCompleted += web_DocumentCompleted;
            //Add a tab when the program is started
            tabControl1.TabPages.Add("New Tab");
            //select the 1st tab 
            tabControl1.SelectTab(_i);
            tabControl1.SelectedTab.Controls.Add(_web);
            _i += 1;
        }

        void web_DocumentCompleted(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser) tabControl1.SelectedTab.Controls[0]).DocumentTitle;
        }

        private void goToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser) tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripMenuItem1.Text);
            }
        }

        //functions to add and remove tabs
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((WebBrowser) tabControl1.SelectedTab.Controls[0]).GoBack();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((WebBrowser) tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void addPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _web = new System.Windows.Forms.WebBrowser();
            _web.Dock = DockStyle.Fill;
            _web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(_i);
            tabControl1.SelectedTab.Controls.Add(_web);
            _i += 1;
        }

        private void removePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                _i -= 1;
            }
        }
    }
}

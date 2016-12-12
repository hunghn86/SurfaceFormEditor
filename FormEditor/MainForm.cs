using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using pF.DesignSurfaceExt;
using pF.DesignSurfaceManagerExt;

namespace FormEditor
{
    public partial class MainForm : Form
    {
        private string _version = string.Empty;

        public string Version
        {
            get
            {
                if (!string.IsNullOrEmpty(_version)) return _version;
                //- Get the actual version of the file hosted in running assembly
                var fvi =
                    System.Diagnostics.FileVersionInfo.GetVersionInfo(
                        System.Reflection.Assembly.GetExecutingAssembly().Location);
                _version = fvi.ProductVersion;
                return _version;
            }
        }

        //- STEP.A
        private readonly DesignSurfaceManagerExt _mgr = new DesignSurfaceManagerExt();

        private IDesignSurfaceExt2 GetCurrentIDesignSurface()
        {
            var index = tabControl1.SelectedIndex;
            if (index >= _mgr.DesignSurfaces.Count)
                return null;
            var surface = _mgr.DesignSurfaces[index];
            return surface as IDesignSurfaceExt2;
        }

        #region Init

        //- ctor
        public MainForm()
        {
            InitializeComponent();

            Initialize();
        }

        #region Initialize Design

        private void Initialize()
        {
            //- STEP.B
            _mgr.PropertyGridHost.Parent = splitContainer.Panel2;
            //- STEP.C
            //- SelectedIndexChanged event fires when the TabControls SelectedIndex or SelectedTab value changes.
            //- give the focus to the DesigneSurface accordingly to te selected TabPage and sync the propertyGrid
            tabControl1.SelectedIndexChanged += (sender, e) =>
            {
                var tabCtrl = sender as TabControl;
                if (tabCtrl != null)
                    _mgr.ActiveDesignSurface = (DesignSurfaceExt2)_mgr.DesignSurfaces[tabCtrl.SelectedIndex];
            };

            CreateToolbox();
            CreateDesignView();
            _mgr.LstModifiedProperties = new List<ModifiedProperties>();
        }

        private void CreateToolbox()
        {
            //- Add the toolboxItems to the future toolbox
            //- the pointer
            var toolPointer = new ToolboxItem
            {
                DisplayName = "<Pointer>",
                Bitmap = new Bitmap(16, 16)
            };
            listBox1.Items.Add(toolPointer);
            //- the control
            listBox1.Items.Add(new ToolboxItem(typeof(Button)));
            listBox1.Items.Add(new ToolboxItem(typeof(ListView)));
            listBox1.Items.Add(new ToolboxItem(typeof(TreeView)));
            listBox1.Items.Add(new ToolboxItem(typeof(TextBox)));
            listBox1.Items.Add(new ToolboxItem(typeof(Label)));
            listBox1.Items.Add(new ToolboxItem(typeof(TabControl)));
            listBox1.Items.Add(new ToolboxItem(typeof(OpenFileDialog)));
            listBox1.Items.Add(new ToolboxItem(typeof(CheckBox)));
            listBox1.Items.Add(new ToolboxItem(typeof(ComboBox)));
            listBox1.Items.Add(new ToolboxItem(typeof(GroupBox)));
            listBox1.Items.Add(new ToolboxItem(typeof(ImageList)));
            listBox1.Items.Add(new ToolboxItem(typeof(Panel)));
            listBox1.Items.Add(new ToolboxItem(typeof(ProgressBar)));
            listBox1.Items.Add(new ToolboxItem(typeof(ToolBar)));
            listBox1.Items.Add(new ToolboxItem(typeof(ToolTip)));
            listBox1.Items.Add(new ToolboxItem(typeof(StatusBar)));
        }

        private void CreateDesignView()
        {
            //- step.0
            var tp = CreateNewTabPage("Design View");
            //- step.1
            var surface = CreateDesignSurface();
            //- step.2
            //- choose an alignment mode...
            ((DesignSurfaceExt2)surface).UseGrid(new System.Drawing.Size(8, 8));
            //- step.3
            //- create the Root compoment, in these case a Form
            var rootComponent = (Control)CreateRootComponent(tp, surface, typeof(Form), new Size(800, 600));
            //int iTabPageSelectedIndex = this.tabControl1.SelectedIndex;
            rootComponent.Text = $"Your Form";
            rootComponent.BackColor = Color.LightGray;
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.tabControl1.Selected += (object snd, TabControlEventArgs ea) =>
            {
                //- select into the propertygrid the current Form
                SelectRootComponent();
            };
        }

        #endregion Init

        //- When the selection changes this sets the PropertyGrid's selected component
        private void OnSelectionChanged(object sender, System.EventArgs e)
        {
            IDesignSurfaceExt isurf = GetCurrentIDesignSurface();
            var selectionService = isurf?.GetIDesignerHost().GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null) this._mgr.PropertyGridHost.SelectedObject = selectionService.PrimarySelection;
        }

        private void SelectRootComponent()
        {
            //- find out the DesignSurfaceExt control hosted by the TabPage
            IDesignSurfaceExt isurf = GetCurrentIDesignSurface();
            if (null != isurf)
                this._mgr.PropertyGridHost.SelectedObject = isurf.GetIDesignerHost().RootComponent;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDesignSurfaceExt isurf = GetCurrentIDesignSurface();
            isurf?.GetUndoEngineExt().Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDesignSurfaceExt isurf = GetCurrentIDesignSurface();
            isurf?.GetUndoEngineExt().Redo();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            MessageBox.Show($@"APV Form Editor IDE developed by APV 
Version is: {Version}", $"APV Form Editor IDE", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void toolStripMenuItemTabOrder_Click(object sender, EventArgs e)
        {
            IDesignSurfaceExt isurf = GetCurrentIDesignSurface();
            isurf?.SwitchTabOrder();
        }

        private void OnMenuClick(object sender, EventArgs e)
        {
            IDesignSurfaceExt isurf = GetCurrentIDesignSurface();
            var toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null) isurf?.DoAction(toolStripMenuItem.Text);
        }

        #region Create Form Menu Event

        //private void newFormUseSnapLinesMenuItem_Click(object sender, EventArgs e)
        //{
        //	//- step.0
        //	TabPage tp = CreateNewTabPage("Use SnapLines");
        //	//- step.1
        //	DesignSurfaceExt2 surface = CreateDesignSurface();
        //	//- step.2
        //	//- choose an alignment mode...
        //	((DesignSurfaceExt2)surface).UseSnapLines();
        //	//- step.3
        //	//- create the Root compoment, in these case a Form
        //	Control rootComponent = (Control)CreateRootComponent(tp, surface, typeof(Form), new Size(400, 400));
        //	int iTabPageSelectedIndex = this.tabControl1.SelectedIndex;
        //	rootComponent.Text = "Root Component hosted by the DesignSurface N." + iTabPageSelectedIndex;
        //	rootComponent.BackColor = Color.Yellow;
        //}

        //private void newFormUseGridandSnapMenuItem_Click(object sender, EventArgs e)
        //{
        //	//- step.0
        //	TabPage tp = CreateNewTabPage("Design View");
        //	//- step.1
        //	DesignSurfaceExt2 surface = CreateDesignSurface();
        //	//- step.2
        //	//- choose an alignment mode...
        //	((DesignSurfaceExt2)surface).UseGrid(new System.Drawing.Size(8, 8));
        //	//- step.3
        //	//- create the Root compoment, in these case a Form
        //	Control rootComponent = (Control)CreateRootComponent(tp, surface, typeof(Form), new Size(400, 400));
        //	int iTabPageSelectedIndex = this.tabControl1.SelectedIndex;
        //	rootComponent.Text = "Root Component hosted by the DesignSurface N." + iTabPageSelectedIndex;
        //	rootComponent.BackColor = Color.Gray;
        //}

        //private void newFormUseGridMenuItem_Click(object sender, EventArgs e)
        //{
        //	//- step.0
        //	TabPage tp = CreateNewTabPage("Use Grid");
        //	//- step.1
        //	DesignSurfaceExt2 surface = CreateDesignSurface();
        //	//- step.2
        //	//- choose an alignment mode...
        //	((DesignSurfaceExt2)surface).UseGridWithoutSnapping(new System.Drawing.Size(16, 16));
        //	//- step.3
        //	//- create the Root compoment, in these case a Form
        //	Control rootComponent = (Control)CreateRootComponent(tp, surface, typeof(Form), new Size(600, 400));
        //	int iTabPageSelectedIndex = this.tabControl1.SelectedIndex;
        //	rootComponent.Text = "Root Component hosted by the DesignSurface N." + iTabPageSelectedIndex;
        //	rootComponent.BackColor = Color.LightGreen;
        //}

        //private void newFormAlignControlByhandMenuItem_Click(object sender, EventArgs e)
        //{
        //	//- step.0
        //	TabPage tp = CreateNewTabPage("Align control by hand");
        //	//- step.1
        //	DesignSurfaceExt2 surface = CreateDesignSurface();
        //	//- step.2
        //	//- choose an alignment mode...
        //	((DesignSurfaceExt2)surface).UseNoGuides();
        //	//- step.3
        //	//- create the Root compoment, in these case a Form
        //	Control rootComponent = (Control)CreateRootComponent(tp, surface, typeof(Form), new Size(640, 480));
        //	int iTabPageSelectedIndex = this.tabControl1.SelectedIndex;
        //	rootComponent.Text = "Root Component hosted by the DesignSurface N." + iTabPageSelectedIndex;
        //	rootComponent.BackColor = Color.LightGray;
        //}

        #endregion

        private TabPage CreateNewTabPage(string text)
        {
            var tp = new TabPage(text);
            this.tabControl1.TabPages.Add(tp);
            return tp;
        }

        private DesignSurfaceExt2 CreateDesignSurface()
        {
            //- step.0
            //- create a DesignSurface and put it inside a Form in DesignTime
            var surface = this._mgr.CreateDesignSurfaceExt2();
            var isurf = (IDesignSurfaceExt2)surface;
            //- step.1
            //- enable the UndoEngines
            isurf.GetUndoEngineExt().Enabled = true;
            //- step.2
            //- try to get a ptr to ISelectionService interface
            //- if we obtain it then hook the SelectionChanged event
            var selectionService = (ISelectionService)(isurf.GetIDesignerHost().GetService(typeof(ISelectionService)));
            if (null != selectionService)
                selectionService.SelectionChanged += new System.EventHandler(OnSelectionChanged);
            //- step.3
            //- Select the service IToolboxService
            //- and hook it to our ListBox
            var tbox = isurf.GetIToolboxService() as ToolboxServiceImp;
            if (null != tbox)
                tbox.Toolbox = listBox1;
            //-
            //- finally return the Designsurface
            return surface;
        }

        private IComponent CreateRootComponent(TabPage tpage, DesignSurfaceExt2 surface, Type controlType,
            Size controlSize)
        {
            try
            {
                var rootComponent = surface.CreateRootComponent(controlType, controlSize);
                this.tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                rootComponent.Site.Name = _mgr.GetValidFormName();
                //- display the DesignSurface
                var view = surface.GetView();
                if (null == view)
                    return null;
                //- change some properties
                view.Text = rootComponent.Site.Name;
                view.Dock = DockStyle.Fill;
                //- Note these assignments
                view.Parent = tpage;
                //- finally enable the Drag&Drop on RootComponent
                ((DesignSurfaceExt2)surface).EnableDragandDrop();
                return rootComponent;
            } //end_try
            catch (Exception ex)
            {
                Console.WriteLine(
                    $@"{Name} CreateRootComponent() has generated errors during loading!Exception: {ex.Message}");
                throw;
            } //end_catch
        }

        private void importDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.IsSaved)
                {
                    var result = MessageBox.Show($"The current design is not saving.\nDo you want to save this design?", @"Question", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            var isSaved = SaveDesign();
                            if (!isSaved) return;
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }

                ImportDesign();
            }
            catch (Exception)
            {
                MessageBox.Show($"Occuring errors.\nPlease try again later.", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void saveDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = SaveDesign();

            if (result)
                MessageBox.Show(@"Export to xml successfully.", @"Infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private bool SaveDesign()
        {
            IDesignSurfaceExt iSurfaceExt = GetCurrentIDesignSurface();

            var formDesign = iSurfaceExt.GetIDesignerHost().RootComponent as Form;

            if (formDesign == null) return false;

            var doc = new XmlDocument();

            try
            {
                // Create a root element
                var rootname = doc.CreateElement("APVRoot");

                var formModified = _mgr.LstModifiedProperties.FirstOrDefault(x => x.ControlID.Equals(formDesign.Name));

                if (formModified != null)
                {
                    foreach (var p in formModified.Properties)
                    {
                        //// Create attributes for root
                        rootname.SetAttribute(p.Key, p.Value.ToString());
                    }
                }

                var controls = ControlHelper.GetAll(formDesign);

                foreach (var control in controls)
                {
                    var controlModified = _mgr.LstModifiedProperties.FirstOrDefault(x => x.ControlID.Equals(control.Name));

                    // Create a node element
                    var controlNode = doc.CreateElement(control.GetType().Name);
                    controlNode.SetAttribute("X", Convert.ToString(control.Location.X, CultureInfo.InvariantCulture));
                    controlNode.SetAttribute("Y", Convert.ToString(control.Location.Y, CultureInfo.InvariantCulture));
                    controlNode.SetAttribute("W", Convert.ToString(control.Size.Width, CultureInfo.InvariantCulture));
                    controlNode.SetAttribute("H", Convert.ToString(control.Size.Height, CultureInfo.InvariantCulture));

                    if (controlModified != null)
                        foreach (var p in controlModified.Properties)
                        {
                            // Create data for node
                            var child = doc.CreateElement(p.Key);
                            child.InnerText = p.Value.ToString();
                            controlNode.AppendChild(child);
                        }

                    // Add node into root
                    rootname.AppendChild(controlNode);
                }

                // Create new declaration
                var dec = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                doc.AppendChild(dec);

                // Insert xml into doc
                doc.AppendChild(rootname);

                var pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var pathDownload = System.IO.Path.Combine(pathUser, "Downloads");

                var saveFileDialog = new SaveFileDialog
                {
                    Filter = @"XML-File | *.xml",
                    FileName = $"APVDesign_{DateTime.Now:yyyyMMdd}.xml",
                    InitialDirectory = pathDownload
                };

                var result = saveFileDialog.ShowDialog();

                if (result != DialogResult.OK) return false;
                doc.Save(saveFileDialog.FileName);

                // Save file
                ControlHelper.IsSaved = true;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show($"Export to xml failure.\nPlease try again later.", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ControlHelper.IsSaved)
            {
                var result = MessageBox.Show(@"Do you want to save current design?", @"Question", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                try
                {
                    switch (result)
                    {
                        case DialogResult.Yes:
                            var isSaved = SaveDesign();
                            if (!isSaved) e.Cancel = true;
                            return;

                        case DialogResult.Cancel:
                            e.Cancel = true;
                            return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Export to xml failure.
Please try again later.", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                var result = MessageBox.Show(@"Do you want to quit application?", @"Question", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Application.Exit();
        }



        /// <summary>
        /// Import design from local source
        /// </summary>
        private void ImportDesign()
        {
            var pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var pathDownload = System.IO.Path.Combine(pathUser, "Downloads");

            var fileDialog = new OpenFileDialog
            {
                Filter = @"XML-File | *.xml",
                InitialDirectory = pathDownload
            };

            if (fileDialog.ShowDialog() != DialogResult.OK) return;

            var doc = new XmlDocument();

            try
            {
                IDesignSurfaceExt iSurfaceExt = GetCurrentIDesignSurface();
                var form = iSurfaceExt.GetIDesignerHost().RootComponent as Form;

                if (form != null)
                {
                    form.Controls.Clear();
                    _mgr.LstModifiedProperties = new List<ModifiedProperties>();
                    doc.Load(fileDialog.FileName);

                    var root = doc.SelectSingleNode("APVRoot");

                    if (root == null)
                    {
                        MessageBox.Show(@"Load file failure.
Please try again later.", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (root.Attributes != null && root.Attributes.Count > 0)
                    {
                        foreach (XmlAttribute attr in root.Attributes)
                        {
                            var pdc = TypeDescriptor.GetProperties(form);
                            var pdS = pdc.Find(attr.Name, false);
                            var convertedValue = ControlHelper.ConvertFromString(pdS.PropertyType, attr.Value);
                            pdS.SetValue(form, convertedValue);
                        }
                    }

                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.NodeType == XmlNodeType.Comment) continue;

                        var typeControl = ControlHelper.GetControlType(node.Name, string.Empty);

                        var x =
                            (node.Attributes != null)
                                ? node.Attributes["X"] == null ? 0 : Convert.ToInt32(node.Attributes["X"].Value)
                                : 0;
                        var y =
                            (node.Attributes != null)
                                ? node.Attributes["Y"] == null ? 0 : Convert.ToInt32(node.Attributes["Y"].Value)
                                : 0;
                        var w =
                            (node.Attributes != null)
                                ? node.Attributes["W"] == null ? 0 : Convert.ToInt32(node.Attributes["W"].Value)
                                : 0;
                        var h =
                            (node.Attributes != null)
                                ? node.Attributes["H"] == null ? 0 : Convert.ToInt32(node.Attributes["H"].Value)
                                : 0;

                        var control = iSurfaceExt.CreateControl(typeControl, new Size(w, h), new Point(x, y));

                        //- set the Size
                        var pdc = TypeDescriptor.GetProperties(control);

                        //- Sets a PropertyDescriptor to the specific property
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.NodeType == XmlNodeType.Comment) continue;
                            var pdS = pdc.Find(child.Name, false);

                            var convertedValue = ControlHelper.ConvertFromString(pdS.PropertyType, child.InnerText);

                            pdS.SetValue(control, convertedValue);
                        }
                    }
                }

                MessageBox.Show(@"Load design config successfully.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
﻿namespace pF.pDesigner {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel.Design;
    using System.ComponentModel.Design.Serialization;
    using System.Drawing.Design;
    using System.IO; 
    using System.Linq;

    using DesignSurfaceExt;
    using DesignSurfaceManagerExt;
    using System.Xml.Linq;
    using System.Diagnostics;


    //- [Note FROM MSDN]:
    //- The DesignSurfaceManager.ActiveDesignSurface property should be set
    //- by the designer's Type user interface
    //- whenever a designer becomes the active window!
    //- That is to say:
    //-   the DesignSurfaceManagerExt is an OBSERVER of UI event: SelectedTab/SelectedIndex Changed
    //- usage:
    //       //- SelectedIndexChanged event fires when the TabControls SelectedIndex or SelectedTab value changes.
    //       //- give the focus to the DesigneSurface accordingly to te selected TabPage and sync the propertyGrid
    //       this.tabControl1.SelectedIndexChanged += ( object sender, EventArgs e ) => {
    //            TabControl tabCtrl = sender as TabControl;
    //            DesignSurfaceManagerExtObject.ActiveDesignSurface = (DesignSurfaceExt2) DesignSurfaceManagerExtObject.DesignSurfaces[tabCtrl.SelectedIndex];
    //       };
    //-
    //- p(ico)Designer class
    public partial class pDesigner : UserControl , IpDesigner {
        private const string _Name_ = "pDesigner";




        //- the DesignSurfaceManagerExt instance must be an OBSERVER
        //- of the UI event which change the active DesignSurface
        //- DesignSurfaceManager is exposed as public getter properties as test facility
        public DesignSurfaceManagerExt DesignSurfaceManager { get; private set; }



        #region ctors
        //- usage:
        //-         if (a){
        //-             // do work
        //-         }//end_if
        //-         else{
        //-             // a is not valid
        //-         }//end_else
        public static implicit operator bool ( pDesigner d ) {
            bool isValid = true;
            //- the object 'd' must be correctly initialized
            isValid &= ( ( null == d.Toolbox ) ? false : true );
            return isValid;
        }


        //- ctor
        public pDesigner() {
            InitializeComponent();

            DesignSurfaceManager = new DesignSurfaceManagerExt();
            DesignSurfaceManager.PropertyGridHost.Parent = this.splitterpDesigner.Panel2;

            Toolbox = null;
            this.Dock = DockStyle.Fill;
                       
        }
        #endregion


        private void tbCtrlpDesigner_SelectedIndexChanged ( object sender, EventArgs e ) {
            TabControl tabCtrl = sender as TabControl;
            int index = this.tbCtrlpDesigner.SelectedIndex;
            if ( index >= 0 )
                DesignSurfaceManager.ActiveDesignSurface = ( DesignSurfaceExt2 ) DesignSurfaceManager.DesignSurfaces[index];
            else {
                DesignSurfaceManager.ActiveDesignSurface = null;
                DesignSurfaceManager.PropertyGridHost.PropertyGrid.SelectedObject = null;
                DesignSurfaceManager.PropertyGridHost.ComboBox.Items.Clear();
            }
        }







        #region IpDesigner Members

        //- to get and set the real Toolbox which is provided by the user
        public ListBox Toolbox { get; set; }

        public TabControl TabControlHostingDesignSurfaces {
            get { return this.tbCtrlpDesigner; }
        }

        public PropertyGridHost PropertyGridHost {
            get { return DesignSurfaceManager.PropertyGridHost; }
        }

        public DesignSurfaceExt2 ActiveDesignSurface {
            get { return DesignSurfaceManager.ActiveDesignSurface as DesignSurfaceExt2; }
        }

        //- Create the DesignSurface and the rootComponent (a .NET Control)
        //- using IDesignSurfaceExt.CreateRootComponent() 
        //- if the alignmentMode doesn't use the GRID, then the gridSize param is ignored
        //- Note:
        //-     the generics param is used to know which type of control to use as RootComponent
        //-     TT is requested to be derived from .NET Control class 
        public DesignSurfaceExt2 AddDesignSurface<TT> (
                                                        int startingFormWidth, int startingFormHeight,
                                                        AlignmentModeEnum alignmentMode, Size gridSize
                                                       ) where TT : Control {
            const string _signature_ = _Name_ + @"::AddDesignSurface<>()";

            if( !this )
                throw new Exception( _signature_ + " - Exception: " + _Name_ + " is not initialized! Please set the Property: IpDesigner::Toolbox before calling any methods!" );


            //- step.0
            //- create a DesignSurface
            DesignSurfaceExt2 surface = DesignSurfaceManager.CreateDesignSurfaceExt2();
            this.DesignSurfaceManager.ActiveDesignSurface = surface;
            //-
            //-
            //- step.1
            //- choose an alignment mode...
            switch( alignmentMode ) {
                case AlignmentModeEnum.SnapLines:
                    surface.UseSnapLines();
                    break;
                case AlignmentModeEnum.Grid:
                    surface.UseGrid( gridSize );
                    break;
                case AlignmentModeEnum.GridWithoutSnapping:
                    surface.UseGridWithoutSnapping( gridSize );
                    break;
                case AlignmentModeEnum.NoGuides:
                    surface.UseNoGuides();
                    break;
                default:
                    surface.UseSnapLines();
                    break;
            }//end_switch
            //-
            //-
            //- step.2
            //- enable the UndoEngine
            ((IDesignSurfaceExt) surface).GetUndoEngineExt().Enabled = true;
            //-
            //-
            //- step.3
            //- Select the service IToolboxService
            //- and hook it to our ListBox
            ToolboxServiceImp tbox = ((IDesignSurfaceExt2) surface).GetIToolboxService() as ToolboxServiceImp;
            //- we don't check if Toolbox is null because the very first check: if(!this)...
            if( null != tbox )
                tbox.Toolbox = this.Toolbox;
            //-
            //-
            //- step.4
            //- create the Root compoment, in these cases a Form
            Control rootComponent = null;
            //- cast to .NET Control because the TT object 
            //- has a constraint: to be a ".NET Control"
            rootComponent = surface.CreateRootComponent( typeof( TT ), new Size( startingFormWidth, startingFormHeight ) ) as Control;
            //- rename the Sited component
            //- (because the user may add more then one Form
            //- and every new Form will be called "Form1"
            //- if we don't set its Name)
            rootComponent.Site.Name = this.DesignSurfaceManager.GetValidFormName();
            //-
            //-
            //- step.5
            //- enable the Drag&Drop on RootComponent
            ((DesignSurfaceExt2) surface).EnableDragandDrop();
            //-
            //-
            //- step.6
            //- IComponentChangeService is marked as Non replaceable service
            IComponentChangeService componentChangeService = (IComponentChangeService) (surface.GetService( typeof( IComponentChangeService ) ));
            if( null != componentChangeService ) {
                //- the Type "ComponentEventHandler Delegate" Represents the method that will
                //- handle the ComponentAdding, ComponentAdded, ComponentRemoving, and ComponentRemoved
                //- events raised for component-level events
                componentChangeService.ComponentChanged += ( Object sender, ComponentChangedEventArgs e )=>
                {
                    // do nothing
                };
                componentChangeService.ComponentAdded += ( Object sender, ComponentEventArgs e )=>
                {
                    DesignSurfaceManager.UpdatePropertyGridHost( surface );
                };
                componentChangeService.ComponentRemoved += ( Object sender, ComponentEventArgs e )=>
                {
                    DesignSurfaceManager.UpdatePropertyGridHost( surface );
                };
            }
            //-
            //-
            //- step.7
            //- now set the Form::Text Property
            //- (because it will be an empty string
            //- if we don't set it)
            Control view = surface.GetView();
            if( null == view )
                return null;
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties( view );
            //- Sets a PropertyDescriptor to the specific property
            PropertyDescriptor pdS = pdc.Find( "Text", false );
            if( null != pdS )
                pdS.SetValue( rootComponent, rootComponent.Site.Name + " (design mode)" );
            //-
            //-
            //- step.8
            //- display the DesignSurface
            string sTabPageText = rootComponent.Site.Name;
            TabPage newPage = new TabPage( sTabPageText );
            newPage.Name = sTabPageText;
            newPage.SuspendLayout(); //----------------------------------------------------
            view.Dock = DockStyle.Fill;
            view.Parent = newPage; //- Note this assignment
            this.tbCtrlpDesigner.TabPages.Add( newPage );
            newPage.ResumeLayout(); //-----------------------------------------------------
            //- select the TabPage created
            this.tbCtrlpDesigner.SelectedIndex = this.tbCtrlpDesigner.TabPages.Count - 1;
            //-
            //-
            //- step.9
            //- finally return the DesignSurface created to let it be modified again by user
            return surface;
        }
            

        public void RemoveDesignSurface( DesignSurfaceExt2 surfaceToErase ) {
            try {

                //- remove the TabPage which has the same name of
                //- the RootComponent host by DesignSurface "surfaceToErase"
                //- Note:
                //-     DesignSurfaceManager continues to reference the DesignSurface erased
                //-     that Designsurface continue to exist but it is no more reachable
                //-     this fact is usefull when generate new names for Designsurfaces just created
                //-     avoiding name clashing
                string dsRootComponentName = surfaceToErase.GetIDesignerHost().RootComponent.Site.Name;
                TabPage tpToRemove = null;
                foreach ( TabPage tp in this.tbCtrlpDesigner.TabPages ) {
                    if ( tp.Name == dsRootComponentName ) {
                        tpToRemove = tp;
                        break;
                    }//end_if
                }//end_foreach
                if ( null != tpToRemove )
                    this.tbCtrlpDesigner.TabPages.Remove ( tpToRemove );


                //- now remove the DesignSurface
                this.DesignSurfaceManager.DeleteDesignSurfaceExt2 ( surfaceToErase );


                //- finally the DesignSurfaceManager remove the DesignSurface
                //- AND set as active DesignSurface the last one
                //- therefore we set as active the last TabPage
                this.tbCtrlpDesigner.SelectedIndex = this.tbCtrlpDesigner.TabPages.Count - 1;
            }//end_try
            catch( Exception exx ) {
                Debug.WriteLine( exx.Message );
                if( null != exx.InnerException )
                    Debug.WriteLine( exx.InnerException.Message );
                
                throw;
            }//end_catch
        }

        public void UndoOnDesignSurface() {
            IDesignSurfaceExt2 isurf = DesignSurfaceManager.ActiveDesignSurface;
            if ( null != isurf )
                isurf.GetUndoEngineExt().Undo();
        }

        public void RedoOnDesignSurface() {
            IDesignSurfaceExt2 isurf = DesignSurfaceManager.ActiveDesignSurface;
            if ( null != isurf )
                isurf.GetUndoEngineExt().Redo();
        }

        public void CutOnDesignSurface() {
            IDesignSurfaceExt isurf = DesignSurfaceManager.ActiveDesignSurface;
            if ( null != isurf )
                isurf.DoAction ( "Cut" );
        }

        public void CopyOnDesignSurface() {
            IDesignSurfaceExt isurf = DesignSurfaceManager.ActiveDesignSurface;
            if ( null != isurf )
                isurf.DoAction ( "Copy" );
        }

        public void PasteOnDesignSurface() {
            IDesignSurfaceExt isurf = DesignSurfaceManager.ActiveDesignSurface;
            if ( null != isurf )
                isurf.DoAction ( "Paste" );
        }

        public void DeleteOnDesignSurface() {
            IDesignSurfaceExt isurf = DesignSurfaceManager.ActiveDesignSurface;
            if ( null != isurf )
                isurf.DoAction ( "Delete" );
        }

        public void SwitchTabOrder() {
            IDesignSurfaceExt isurf = DesignSurfaceManager.ActiveDesignSurface;
            if ( null != isurf )
                isurf.SwitchTabOrder();
        }
        
        #endregion

    }//end_class
}//end_namespace

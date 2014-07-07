using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace NguyenNgocQuocBao
{
    /// <summary>
    /// Summary description for btnCapNhatOngNganh.
    /// </summary>
    [Guid("809b80bd-6a25-46fd-84e6-944244c4160d")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("NguyenNgocQuocBao.btnCapNhatOngNganh")]
    public sealed class btnCapNhatOngNganh : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IApplication m_application;
        public btnCapNhatOngNganh()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text 
            base.m_caption = "";  //localizable text 
            base.m_message = "";  //localizable text
            base.m_toolTip = "Cap Nhat Ong Nganh";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_ArcMapTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        public static IApplication pApp;
        IMxApplication pMxApp;
        IMxDocument pMxDoc;
        public static IMap pMap;
        public static IActiveView pActiveView;
        IEnvelope pEnvelope;
        ///
        INewEnvelopeFeedback m_pFeedbackEnv;
        IPoint m_pPoint;
        bool m_bIsMouseDown;

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            m_application = hook as IApplication;

            //Disable if it is not ArcMap
            if (hook is IMxApplication)
            {
                base.m_enabled = true;
                pApp = (IApplication)hook;
                pMxApp = (IMxApplication)pApp;
                pMxDoc = (IMxDocument)pApp.Document;
                pMap = pMxDoc.FocusMap;
                pActiveView = (IActiveView)pMap;
                pEnvelope = pMxDoc.CurrentLocation.Envelope;
            }
            else
                base.m_enabled = false;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add btnCapNhatOngNganh.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add btnCapNhatOngNganh.OnMouseDown implementation
            pMxDoc = (IMxDocument)pApp.Document;
            pActiveView = (IActiveView)pMxDoc.FocusMap;
            m_pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            m_bIsMouseDown = true;
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add btnCapNhatOngNganh.OnMouseMove implementation
            if (m_bIsMouseDown)
            {
                pMxDoc = (IMxDocument)pApp.Document;
                pActiveView = (IActiveView)pMxDoc.FocusMap;
                if (m_pFeedbackEnv == null)
                {
                    m_pFeedbackEnv = new NewEnvelopeFeedback();
                    m_pFeedbackEnv.Display = pActiveView.ScreenDisplay;
                    m_pFeedbackEnv.Start(m_pPoint);
                }
                m_pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                m_pFeedbackEnv.MoveTo(m_pPoint);
            }    
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add btnCapNhatOngNganh.OnMouseUp implementation
            IEnvelope pEnv;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            if (m_pFeedbackEnv != null)
            {
                pEnv = m_pFeedbackEnv.Stop();
                pMxDoc.FocusMap.SelectByShape(pEnv, null, false);
            }
            else
            {
                pMxDoc.FocusMap.SelectByShape(m_pPoint, null, false);
            }
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            QuerySelectedFeatureUpdate();
            m_pFeedbackEnv = null;
            m_bIsMouseDown = false;
        }

        public void QuerySelectedFeatureUpdate()
        {
            IEnumLayer pEnumLayer;
            IFeatureCursor pFeatureCursor;
            IFeatureLayer pFeatureLayer;
            IFeatureSelection pFeatureSelection;
            ISelectionSet pSelectionSet;
            IFeature pFeature;
            ICursor cursor;
            IUID pUid = new UID();
            pUid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
            pEnumLayer = pMap.get_Layers((UID)pUid, true);
            pEnumLayer.Reset();
            pFeatureLayer = (IFeatureLayer)pEnumLayer.Next();
            pFeatureCursor = null;
            if (pFeatureLayer.Valid)
            {
                while (!pFeatureLayer.Valid)
                {
                    pFeatureLayer = (IFeatureLayer)pEnumLayer.Next();
                }
                if (!pFeatureLayer.Valid)
                {
                    pFeatureLayer = (IFeatureLayer)pEnumLayer.Next();
                }
                do
                {
                    pFeatureSelection = (IFeatureSelection)pFeatureLayer;
                    pSelectionSet = pFeatureSelection.SelectionSet;
                    if (pSelectionSet != null)
                    {
                        pSelectionSet.Search(null, false, out cursor);
                        pFeatureCursor = (IFeatureCursor)cursor;
                        pFeature = pFeatureCursor.NextFeature();
                        if (pFeature != null)
                        {
                            if (pFeatureLayer.FeatureClass.AliasName == "OngNganh")
                            {
                                frmOngNganh frm = new frmOngNganh();
                                frm.pFeature = pFeature;
                                frm.ShowDialog();
                            }
                        }
                        pFeatureLayer = (IFeatureLayer)pEnumLayer.Next();
                        if (pFeatureLayer == null)
                            break;
                        else if (pFeatureLayer.Valid == null)
                            pFeatureLayer = (IFeatureLayer)pEnumLayer.Next();
                    }
                } while (pFeatureLayer != null);
            }
        }

        public override bool Enabled
        {
            get
            {
                if (btnKetNoi.pWS != null)
                    return true;
                else
                    return false;
            }
        }

        #endregion
    }
}

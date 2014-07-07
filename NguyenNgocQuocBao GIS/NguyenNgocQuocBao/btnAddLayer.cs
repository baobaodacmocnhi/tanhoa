using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace NguyenNgocQuocBao
{
    /// <summary>
    /// Summary description for btnAddLayer.
    /// </summary>
    [Guid("885e3984-4855-45de-8f87-a945e1322c87")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("NguyenNgocQuocBao.btnAddLayer")]
    public sealed class btnAddLayer : BaseCommand
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
        public btnAddLayer()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text
            base.m_caption = "";  //localizable text
            base.m_message = "";  //localizable text 
            base.m_toolTip = "";  //localizable text 
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        IApplication pApp;
        IMxApplication pMxApp;
        IMxDocument pMxDoc;
        IMap pMap;
        IActiveView pActiveView;
        IEnvelope pEnvelope;

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

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

        public IFeatureLayer addFeatureClassToMap(IWorkspace pWStemp, string strLayerName)
        {
            IFeatureWorkspace pFeatureWS = (IFeatureWorkspace)pWStemp;
            IFeatureClass pFeatureClass;
            IFeatureLayer pFLayer = new FeatureLayer();
            pFeatureClass = pFeatureWS.OpenFeatureClass(strLayerName);
            pFLayer.FeatureClass = pFeatureClass;
            pFLayer.Name = pFeatureClass.AliasName;
            return pFLayer;
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add btnAddLayer.OnClick implementation
            IWorkspace pWorkspace;
            pWorkspace = btnKetNoi.pWS;
            pMap.AddLayer(addFeatureClassToMap(pWorkspace, "HanhChinh"));
            pMap.AddLayer(addFeatureClassToMap(pWorkspace, "Thua"));
            pMap.AddLayer(addFeatureClassToMap(pWorkspace, "OngPhanPhoi"));
            pMap.AddLayer(addFeatureClassToMap(pWorkspace, "OngNganh"));
            pMap.AddLayer(addFeatureClassToMap(pWorkspace, "DongHoKhachHang"));
        }

        #endregion
    }
}

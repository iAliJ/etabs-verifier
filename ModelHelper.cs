using System;
using System.IO;
using ETABSv17;

namespace EtabsAPI
{
    public class ModelHelper
    {
        // Private fields
        // Public properties
        public cSapModel EModel { get; private set; }
        public Model EtabsModel;

        // Constructor
        public ModelHelper(Model etabsModel)
        {
            EModel = default(cSapModel);
            this.EtabsModel = etabsModel;
        }

        // Start ETABS And open an existing model
        public void OpenModel()
        {
            ETABSv17.cHelper myHelper = new ETABSv17.Helper();
            cOAPI myETABSObject = myHelper.CreateObjectProgID("CSI.ETABS.API.ETABSObject");
            myETABSObject.ApplicationStart();
            EModel = myETABSObject.SapModel;
            Model.Instance = EModel;
            EModel.InitializeNewModel(ETABSv17.eUnits.kN_mm_C);
            if(File.Exists(EtabsModel.Path))
            {
                BackupEtabsFile();
                EModel.File.OpenFile(EtabsModel.Path);
            }
            else
            {
                throw new FileNotFoundException($"Cannot find ETABS file {EtabsModel.Name}, please check the name.");
            }
        }

        // Copy a backup of ETABS file
        private void BackupEtabsFile()
        {            
            string backupLocation = $"{EtabsModel.Directory}\\Backup";
            Directory.CreateDirectory(backupLocation);
            string filepath = Path.Combine(backupLocation, EtabsModel.Name);
            if(File.Exists(filepath))
            {
                filepath = Path.Combine(EtabsModel.Directory + @"\Backup", Path.GetFileNameWithoutExtension(filepath));
                filepath += DateTime.Now.ToString("yyyyMMddHHmm") + ".EDB";                
            }
            File.Copy(EtabsModel.Path, filepath);                
        }
    }
}
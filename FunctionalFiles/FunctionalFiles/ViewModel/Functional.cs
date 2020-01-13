using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunctionalFiles.Model;
using WinForms = System.Windows.Forms;

namespace FunctionalFiles.ViewModel
{
    public class Functional : ViewModelBase
    {
        private ModelFuncFiles model;

        public string Dir
        {
            get => model.Path;
            set
            {
                model.Path = value; OnPropertyChanged(nameof(Dir));
            }
        }

        public Functional()
        {
            model = new ModelFuncFiles();
        }

        private RelayCommand _calcCommand;
        public RelayCommand CalcCommand => _calcCommand ?? (_calcCommand =
                                    new RelayCommand(x => model.CalcPath()));

        private RelayCommand _newFilesCommand;
        
        public RelayCommand NewFilesCommand => _newFilesCommand ?? (_newFilesCommand =
                                    new RelayCommand(x => { model.ClearPath();  model.FillPath(); }));
        
        private RelayCommand _dirCommand;

        public RelayCommand DirCommand => _dirCommand ?? (_dirCommand =
                                    new RelayCommand(x => 
                                    { 
                                        var fbd = new WinForms.FolderBrowserDialog();
                                        if (fbd.ShowDialog() == DialogResult.OK) Dir = fbd.SelectedPath;                                        
                                    }));
    }
}

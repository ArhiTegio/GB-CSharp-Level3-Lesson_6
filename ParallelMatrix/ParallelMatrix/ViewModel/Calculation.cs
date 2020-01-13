using ParallelMatrix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelMatrix.ViewModel
{
    public class Calculation : ViewModelBase
    {        
        private ModelMatrix model;

        public string Matrix1 
        { 
            get
            {
                var text = new StringBuilder();
                for(int i = 0; i < model.Matrix1.M; ++i)
                {
                    for (int j = 0; j < model.Matrix1.N; ++j)
                    {
                        text.Append(model.Matrix1.data[i, j]);
                        text.Append(" ");
                    }
                    text.Append(Environment.NewLine);
                }
                return text.ToString();
            }
        }
        public string Matrix2
        {
            get
            {
                var text = new StringBuilder();
                for (int i = 0; i < model.Matrix2.M; ++i)
                {
                    for (int j = 0; j < model.Matrix2.N; ++j)
                    {
                        text.Append(model.Matrix2.data[i, j]);
                        text.Append(" ");
                    }
                    text.Append(Environment.NewLine);
                }
                return text.ToString();
            }
        }

        public string Matrix3
        {
            get
            {
                var text = new StringBuilder();
                for (int i = 0; i < model.Matrix3.M; ++i)
                {
                    for (int j = 0; j < model.Matrix3.N; ++j)
                    {
                        text.Append(model.Matrix3.data[i, j]);
                        text.Append(" ");
                    }
                    text.Append(Environment.NewLine);
                }
                return text.ToString();
            }
        }

        public int N { get => model.N; set { model.N = value; OnPropertyChanged(nameof(N)); } }

        public Calculation()
        {
            model = new ModelMatrix();
            OnPropertyChanged(nameof(Matrix1));
            OnPropertyChanged(nameof(Matrix2));
            OnPropertyChanged(nameof(Matrix3));
        }

        private RelayCommand _calcCommand;
        public RelayCommand CalcCommand => _calcCommand ?? (_calcCommand =
                                            new RelayCommand(ExecuteCalcCommand,
                                                CanCalcCommand));
        public void ExecuteCalcCommand(object parameter)
        {
            model.MultiplyMatrix();
            OnPropertyChanged(nameof(Matrix3));
        }


        private RelayCommand _matrixCommand;
        public RelayCommand NewMatrixCommand => _matrixCommand ?? (_matrixCommand =
                                    new RelayCommand(ExecuteNewMatrixCommand,
                                        CanNewMatrixCommand));
        public void ExecuteNewMatrixCommand(object parameter)
        {
            model = new ModelMatrix();
            OnPropertyChanged(nameof(Matrix1));
            OnPropertyChanged(nameof(Matrix2));
            OnPropertyChanged(nameof(Matrix3));
        }

        public bool CanNewMatrixCommand(object parameter) => true;
        public bool CanCalcCommand(object parameter) => 
            model.Matrix1 != null && model.Matrix2 != null && model.Matrix3 != null;
    }
}

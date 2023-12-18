using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WorldChaCha
{
    /// <summary>
    /// Логика взаимодействия для EditMaterials.xaml
    /// </summary>
    public partial class EditMaterials : Page
    {
        byte[] im;
        private Material _currentMaterial = new Material();
        bool imgChange = false;
        public EditMaterials(Material selectedMaterial)
        {
            InitializeComponent();
            if (selectedMaterial != null)
                _currentMaterial = selectedMaterial;
            DataContext = _currentMaterial;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                im = File.ReadAllBytes(ofd.FileName);
                imnn.Source = new BitmapImage(new Uri(ofd.FileName));
                imgChange = true;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(_currentMaterial.Наименование))
                errors.AppendLine("Укажите название материала");
            if (string.IsNullOrEmpty(_currentMaterial.ТипМатериала))
                errors.AppendLine("Укажите тип материала");
            if (_currentMaterial.Цена < 0)
                errors.AppendLine("Цена не может быть отрицательной");
            if (_currentMaterial.КолНаСкладе < 0)
                errors.AppendLine("Количество материала на складе не может быть отрицательным");
            if (_currentMaterial.МинКолНаСкладе < 0)
                errors.AppendLine("Минимальное количество материала на складе не может быть отрицательным");
            if (_currentMaterial.КолУпаковки < 0)
                errors.AppendLine("Количество материала в одной упаковки не может быть отрицательным");
            if (string.IsNullOrEmpty(_currentMaterial.ЕдиницаИзм))
                errors.AppendLine("Укажите единицу измерения");

            if (_currentMaterial.IDМатериала == 0 || imgChange == true)
            {
                _currentMaterial.ИзображениеМатериала = im;
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterial.IDМатериала == 0)
            {
                WorldChaChaEntities.GetContext().Material.Add(_currentMaterial);
            }
            try
            {
                WorldChaChaEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация Сохранена!");
                Tran.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            imgChange = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WorldChaCha
{
    /// <summary>
    /// Логика взаимодействия для Materials.xaml
    /// </summary>
    public partial class Materials : Page
    {
        public Materials()
        {
            InitializeComponent();
            var allTypes = WorldChaChaEntities.GetContext().TypeCom().ToList();
            allTypes.Insert(0, "ВсеТипы");
            ComboType.ItemsSource = allTypes;
            ComboType.SelectedIndex = 0;
            UpdateMatetials();
        }
        private void UpdateMatetials()
        {
            var currentMaterials = WorldChaChaEntities.GetContext().Material.ToList();
            if (ComboType.SelectedIndex > 0)
            {
                currentMaterials = currentMaterials.Where(p => p.ТипМатериала == ComboType.Items[ComboType.SelectedIndex].ToString()).ToList();
            }
            currentMaterials = currentMaterials.Where(p => p.Наименование.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            LVistMaterials.ItemsSource = currentMaterials.OrderBy(p => p.Наименование).ToList();

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMatetials();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMatetials();
        }

        private void btn_Edit(object sender, RoutedEventArgs e)
        {
            Tran.MainFrame.Navigate(new EditMaterials((sender as Button).DataContext as Material));
        }
        private void btn_Delete(object sender, RoutedEventArgs e)
        {
            var TourForRemoving = LVistMaterials.SelectedItems.Cast<Material>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить слудующие элемент", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    WorldChaChaEntities.GetContext().Material.Remove((sender as Button).DataContext as Material);
                    WorldChaChaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    LVistMaterials.ItemsSource = WorldChaChaEntities.GetContext().Material.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnnew_Click(object sender, RoutedEventArgs e)
        {
            Tran.MainFrame.Navigate(new EditMaterials(null));
        }
    }
}
